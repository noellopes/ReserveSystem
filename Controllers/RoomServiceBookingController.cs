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
    public class RoomServiceBookingController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomServiceBookingController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomServiceBooking
        public async Task<IActionResult> Index(int page = 1, string searchService = "", string searchRoom = "")
        {
            if (_context.RoomServiceBooking == null)
            {
                return Problem("Entity set 'ReserveSystemContext.RoomServiceBooking' is null.");
            }

            var bookings = from b in _context.RoomServiceBooking.Include(b => b.RoomService) select b;

            if (searchService != "")
            {
                bookings = from s in bookings where s.RoomService.Name.Contains(searchService) select s;
            }

            if (searchRoom != "")
            {
                bookings = from r in bookings where r.Room.Id.ToString().Contains(searchRoom) select r;
            }

            var model = new RoomServiceViewModel
            {
                // Apply pagination
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    // Get total items count after applying filters
                    TotalItems = await bookings.CountAsync()
                }
            };

            model.RoomServiceBookings = await bookings
                                    .OrderBy(b => b.Room)
                                    .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.PageSize)
                                    .Take(model.PagingInfo.PageSize)
                                    .ToListAsync();

            model.RoomServices = new SelectList(_context.RoomService, "Id", "Name");
            model.Rooms = new SelectList(_context.Room, "Id", "Id");

            model.SearchService = searchService;
            model.SearchRoom = searchRoom;

            return View(model);
        }

        // GET: RoomServiceBooking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error));
            }

            var roomServiceBooking = await _context.RoomServiceBooking
                .Include(r => r.Client)
                .Include(r => r.Room)
                .Include(r => r.RoomService)
                .Include(r => r.Staff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomServiceBooking == null)
            {
                return RedirectToAction(nameof(Error));
            }

            return View(roomServiceBooking);
        }

        // GET: RoomServiceBooking/Create
        public IActionResult Create()
        {

            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id");
            ViewData["RoomServiceId"] = new SelectList(_context.RoomService, "Id", "Name");
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name");

            return View();
        }

        // POST: RoomServiceBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create([Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            if (ModelState.IsValid)
            {
                // Instead of saving directly, show confirmation
                ViewBag.Action = "Create";
                return View("ConfirmAction", roomServiceBooking);
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", roomServiceBooking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", roomServiceBooking.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomService, "Id", "Name", roomServiceBooking.RoomServiceId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name", roomServiceBooking.StaffId);
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", roomServiceBooking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", roomServiceBooking.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomService, "Id", "Name", roomServiceBooking.RoomServiceId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name", roomServiceBooking.StaffId);
            return View("Create", roomServiceBooking);
        }

        // GET: RoomServiceBooking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error));
            }

            var roomServiceBooking = await _context.RoomServiceBooking.FindAsync(id);
            if (roomServiceBooking == null)
            {
                return RedirectToAction(nameof(Error));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", roomServiceBooking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", roomServiceBooking.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomService, "Id", "Name", roomServiceBooking.RoomServiceId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name", roomServiceBooking.StaffId);
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", roomServiceBooking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", roomServiceBooking.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomService, "Id", "Name", roomServiceBooking.RoomServiceId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name", roomServiceBooking.StaffId);
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", roomServiceBooking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", roomServiceBooking.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.RoomService, "Id", "Name", roomServiceBooking.RoomServiceId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name", roomServiceBooking.StaffId);
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
                .Include(r => r.Client)
                .Include(r => r.Room)
                .Include(r => r.RoomService)
                .Include(r => r.Staff)
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

        private bool RoomServiceBookingExists(int id)
        {
            return _context.RoomServiceBooking.Any(e => e.Id == id);
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
                switch (statusCode.Value)
                {
                    case 404:
                        ViewBag.ErrorMessage = "The requested page was not found.";
                        break;
                    case 500:
                        ViewBag.ErrorMessage = "An internal server error occurred.";
                        break;
                    default:
                        ViewBag.ErrorMessage = "An error occurred while processing your request.";
                        break;
                }
            }

            return View(error);
        }
    }
}
