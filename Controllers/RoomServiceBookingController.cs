using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Data;
using ReserveSystem.Models;

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
        public async Task<IActionResult> Index(int roomServiceId, int searchInt, int page=1)
        {
            if (_context.RoomServiceBooking == null)
            {
                return Problem("Entity set 'ReserveSystemContext.RoomServiceBooking' is null.");
            }

            // LINQ query to get list of room service ids
            IQueryable<int> serviceIdQuery = from rsb in _context.RoomServiceBooking
                                            orderby rsb.RoomServiceId
                                            select rsb.RoomServiceId;

            var roomServiceBookings = from rsb in _context.RoomServiceBooking
                                    select rsb;

            // Apply search filters
            if (searchInt > 0)
            {
                roomServiceBookings = roomServiceBookings.Where(rsb => rsb.Id == searchInt);
            }

            if (roomServiceId > 0)
            {
                roomServiceBookings = roomServiceBookings.Where(rsb => rsb.RoomServiceId == roomServiceId);
            }

            var model = new RoomServiceViewModel();

            model.PagingInfo = new PagingInfo {
                CurrentPage = page,
                // Get total items count after applying filters
                TotalItems = await roomServiceBookings.CountAsync()
            };
            
            var roomServiceBookingList = await roomServiceBookings
                                    .OrderBy(rsb => rsb.Id)
                                    .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.PageSize)
                                    .Take(model.PagingInfo.PageSize)
                                    .ToListAsync();

            // Apply pagination
            model.RoomServicesIds = new SelectList(await serviceIdQuery.Distinct().ToListAsync());
            model.RoomServiceBookings = roomServiceBookingList;

            return View(model);
        }

        // GET: RoomServiceBooking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServiceBooking = await _context.RoomServiceBooking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomServiceBooking == null)
            {
                return NotFound();
            }

            return View(roomServiceBooking);
        }

        // GET: RoomServiceBooking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomServiceBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomServiceBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomServiceBooking);
        }

        // GET: RoomServiceBooking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServiceBooking = await _context.RoomServiceBooking.FindAsync(id);
            if (roomServiceBooking == null)
            {
                return NotFound();
            }
            return View(roomServiceBooking);
        }

        // POST: RoomServiceBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            if (id != roomServiceBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomServiceBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServiceBookingExists(roomServiceBooking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roomServiceBooking);
        }

        // GET: RoomServiceBooking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServiceBooking = await _context.RoomServiceBooking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomServiceBooking == null)
            {
                return NotFound();
            }

            return View(roomServiceBooking);
        }

        // POST: RoomServiceBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomServiceBooking = await _context.RoomServiceBooking.FindAsync(id);
            if (roomServiceBooking != null)
            {
                _context.RoomServiceBooking.Remove(roomServiceBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomServiceBookingExists(int id)
        {
            return _context.RoomServiceBooking.Any(e => e.Id == id);
        }
    }
}
