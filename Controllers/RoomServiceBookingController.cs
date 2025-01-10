using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Diagnostics;

namespace ReserveSystem.Controllers
{
    public class RoomServiceBookingController(ReserveSystemContext context) : Controller
    {
        private readonly ReserveSystemContext _context = context;

        // GET: RoomServiceBooking
        public async Task<IActionResult> Index(int roomServiceId = 0, int roomId = 0, int page = 1)
        {
            if (_context.RoomServiceBooking == null)
            {
                return Problem("Entity set 'ReserveSystemContext.RoomServiceBooking' is null.");
            }

            var bookings = from b in _context.RoomServiceBooking
                        .Include(b => b.RoomService)
                        .Include(b => b.Staff)
                        .Include(b => b.Client)
                        .Include(b => b.Room)
                        select b;

            if (roomServiceId != 0)
            {
                bookings = bookings.Where(b => b.RoomServiceId == roomServiceId);
            }

            if (roomId != 0)
            {
                bookings = bookings.Where(b => b.RoomId == roomId);
            }

            var model = new RoomServiceViewModel
            {   
                RoomServiceId = roomServiceId, // Preserve room service filter
                RoomId = roomId,         // Preserve search filter
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = await bookings.CountAsync()
                },
                // Get room services for dropdown
                RoomServices = new SelectList(
                    await _context.RoomService
                        .Where(rs => rs.ServiceActive)
                        .OrderBy(rs => rs.Name)
                        .ToListAsync(), 
                    "Id", 
                    "Name", 
                    roomServiceId
                ),
                Rooms = new SelectList(
                    await _context.Room
                        .OrderBy(r => r.Number)
                        .ToListAsync(),
                    "Id",
                    "Number",
                    roomId
                )
            };

            // Get paginated results
            var roomServiceBookingList = await bookings
                .OrderBy(b => b.Id)
                .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.PageSize)
                .Take(model.PagingInfo.PageSize)
                .ToListAsync();

            model.RoomServiceBookings = roomServiceBookingList;

            return View(model);
        }

        // GET: RoomServiceBooking/Details/5
        public async Task<IActionResult> Details(int? id, int page = 1, int roomServiceId = 0, int roomId = 0)
        {
            if (id == null) return RedirectToAction(nameof(Error));

            var booking = await _context.RoomServiceBooking
                .Include(b => b.RoomService)
                .Include(b => b.Staff)
                .Include(b => b.Client)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (booking == null) return RedirectToAction(nameof(Error));

            // Preserve state in ViewData
            ViewData["CurrentPage"] = page;
            ViewData["RoomServiceId"] = roomServiceId;
            ViewData["RoomId"] = roomId;

            return View(booking);
        }

        // GET: RoomServiceBooking/Create
        public async Task<IActionResult> Create()
        {
            // Set default values for hidden fields
            PopulateHiddenFields();

            // Populate select lists
            await PopulateSelectLists();

            return View();
        }

        // POST: RoomServiceBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create([Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            // Set default values for hidden fields
            PopulateHiddenFields();

            if (ModelState.IsValid)
            {
                // Instead of saving directly, show confirmation
                ViewBag.Action = "Create";
                return View("ConfirmAction", roomServiceBooking);
            }

            // If we got this far, something failed, redisplay form
            await PopulateSelectLists();
            return View(roomServiceBooking);
        }

        // Add a new action to handle the confirmed create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmCreate([Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomServiceBooking);
                await _context.SaveChangesAsync();
                ViewBag.Action = "Create";
                return View("ActionSuccess");
            }
            return View("Create", roomServiceBooking);
        }

        // GET: RoomServiceBooking/Edit/5
        public async Task<IActionResult> Edit(int? id, int page = 1, int selectedRoomServiceId = 0, int selectedRoomId = 0)
        {
            if (id == null) return RedirectToAction(nameof(Error));

            var roomServiceBooking = await _context.RoomServiceBooking
                .Include(b => b.RoomService)
                .Include(b => b.Staff)
                .Include(b => b.Client)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (roomServiceBooking == null) return RedirectToAction(nameof(Error));

            // Preserve state in ViewData
            ViewData["CurrentPage"] = page;
            ViewData["SelectedRoomServiceId"] = selectedRoomServiceId;  
            ViewData["SelectedRoomId"] = selectedRoomId;

            await PopulateSelectLists();
            
            // Set form values
            ViewBag.DateTime = roomServiceBooking.DateTime;
            ViewBag.ClientFeedback = roomServiceBooking.ClientFeedback;
            ViewBag.Price = roomServiceBooking.ValueToPay;
            ViewBag.BookingStatus = roomServiceBooking.BookedState;
            ViewBag.StaffConfirmation = roomServiceBooking.StaffConfirmation;
            ViewBag.PaymentStatus = roomServiceBooking.PaymentDone;
            ViewBag.StartDate = roomServiceBooking.StartDate;
            ViewBag.EndDate = roomServiceBooking.EndDate;
            
            return View(roomServiceBooking);
        }

        // POST: RoomServiceBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            if (id != roomServiceBooking.Id)
            {
                return RedirectToAction(nameof(Error));
            }

            if (ModelState.IsValid)
            {
                ViewBag.Action = "Edit"; 
                return View("ConfirmAction", roomServiceBooking);
            }
            return View(roomServiceBooking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmEdit(int id, [Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            if (id != roomServiceBooking.Id)
            {
                return RedirectToAction(nameof(Error));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomServiceBooking);
                    await _context.SaveChangesAsync();
                    ViewBag.Action = "Edit";
                    return View("ActionSuccess");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServiceBookingExists(roomServiceBooking.Id))
                    {
                        return RedirectToAction(nameof(Error));
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Edit", roomServiceBooking);
        }

        // GET: RoomServiceBooking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error));
            }

            var roomServiceBooking = await _context.RoomServiceBooking
                .Include(b => b.RoomService)
                .Include(b => b.Staff)
                .Include(b => b.Client)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (roomServiceBooking == null)
            {
                return RedirectToAction(nameof(Error));
            }

            return View(roomServiceBooking);
        }

        // POST: RoomServiceBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var roomServiceBooking = _context.RoomServiceBooking.Find(id);
            if (roomServiceBooking == null)
            {
                return RedirectToAction(nameof(Error));
            }
            
            ViewBag.Action = "Delete";
            return View("ConfirmAction", roomServiceBooking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var roomServiceBooking = await _context.RoomServiceBooking.FindAsync(id);
            if (roomServiceBooking != null)
            {
                _context.RoomServiceBooking.Remove(roomServiceBooking);
                await _context.SaveChangesAsync();
                ViewBag.Action = "Delete";
                return View("ActionSuccess"); 
            }

            return RedirectToAction(nameof(Error));
        }

        // POST: RoomServiceBooking/BulkDelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteModel model)
        {
            if (model?.Ids == null || !model.Ids.Any())
                return BadRequest();

            try
            {
                var bookingsToDelete = await _context.RoomServiceBooking
                    .Where(b => model.Ids.Contains(b.Id))
                    .ToListAsync();

                if (bookingsToDelete.Any())
                {
                    _context.RoomServiceBooking.RemoveRange(bookingsToDelete);
                    await _context.SaveChangesAsync();
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private bool RoomServiceBookingExists(int id)
        {
            return _context.RoomServiceBooking.Any(e => e.Id == id);
        }

        // Helper method to populate select lists
        private async Task PopulateSelectLists()
        {
            // Create select lists
            ViewBag.RoomServices = new SelectList(await _context.RoomService
                .Where(rs => rs.ServiceActive)
                .OrderBy(rs => rs.Name)
                .Distinct()
                .ToListAsync(), "Id", "Name");

            ViewBag.Staff = new SelectList(await _context.Staff
                .OrderBy(s => s.Name)
                .Distinct()
                .ToListAsync(), "Id", "Name");

            ViewBag.Clients = new SelectList(await _context.Client
                .OrderBy(c => c.Name)
                .Distinct()
                .ToListAsync(), "Id", "Name");

            ViewBag.Rooms = new SelectList(await _context.Room
                .OrderBy(r => r.Number)
                .Distinct()
                .ToListAsync(), "Id", "Number");
        }

        private void PopulateHiddenFields()
        {
            ViewBag.DateTime = DateTime.Now;
            ViewBag.ClientFeedback = null;
            ViewBag.Price = 0.00m;
            ViewBag.BookingStatus = true;
            ViewBag.StaffConfirmation = false;
            ViewBag.PaymentStatus = false;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        {
            var error = new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            // Default error message
            ViewBag.ErrorMessage = "An error occurred while processing your request.";
            
            if (statusCode.HasValue)
            {
                ViewBag.ErrorMessage = statusCode.Value switch
                {
                    404 => "The requested page was not found.",
                    500 => "An internal server error occurred.",
                    _ => "An error occurred while processing your request.",
                };
            }

            return View(error);
        }
    }

    public class BulkDeleteModel
    {
        public required int[] Ids { get; set; }
    }
}
