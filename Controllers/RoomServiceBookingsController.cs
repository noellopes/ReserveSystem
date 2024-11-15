using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class RoomServiceBookingsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomServiceBookingsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomServiceBookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomServiceBooking.ToListAsync());
        }

        // GET: RoomServiceBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServiceBooking = await _context.RoomServiceBooking
                .FirstOrDefaultAsync(m => m.RoomServiceBookingId == id);
            if (roomServiceBooking == null)
            {
                return NotFound();
            }

            return View(roomServiceBooking);
        }

        // GET: RoomServiceBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomServiceBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomServiceBookingId,RoomServiceId,StaffId,ClientId,RoomId,StartDate,StartTime,EndDate,IsReserved,StaffConfirmation,ClientFeedback,AmountToPay,PaymentMade")] RoomServiceBooking roomServiceBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomServiceBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomServiceBooking);
        }

        // GET: RoomServiceBookings/Edit/5
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

        // POST: RoomServiceBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomServiceBookingId,RoomServiceId,StaffId,ClientId,RoomId,StartDate,StartTime,EndDate,IsReserved,StaffConfirmation,ClientFeedback,AmountToPay,PaymentMade")] RoomServiceBooking roomServiceBooking)
        {
            if (id != roomServiceBooking.RoomServiceBookingId)
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
                    if (!RoomServiceBookingExists(roomServiceBooking.RoomServiceBookingId))
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

        // GET: RoomServiceBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServiceBooking = await _context.RoomServiceBooking
                .FirstOrDefaultAsync(m => m.RoomServiceBookingId == id);
            if (roomServiceBooking == null)
            {
                return NotFound();
            }

            return View(roomServiceBooking);
        }

        // POST: RoomServiceBookings/Delete/5
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
            return _context.RoomServiceBooking.Any(e => e.RoomServiceBookingId == id);
        }
    }
}
