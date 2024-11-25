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
    public class RoomBookingsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomBookingsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomBookings
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.RoomBooking.Include(r => r.booking).Include(r => r.room);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: RoomBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBooking
                .Include(r => r.booking)
                .Include(r => r.room)
                .FirstOrDefaultAsync(m => m.RoomBookingId == id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            return View(roomBooking);
        }

        // GET: RoomBookings/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingId");
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId");
            return View();
        }

        // POST: RoomBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomBookingId,PersonsNumber,CleaningOption,BookingId,RoomId")] RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingId", roomBooking.BookingId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", roomBooking.RoomId);
            return View(roomBooking);
        }

        // GET: RoomBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBooking.FindAsync(id);
            if (roomBooking == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingId", roomBooking.BookingId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", roomBooking.RoomId);
            return View(roomBooking);
        }

        // POST: RoomBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomBookingId,PersonsNumber,CleaningOption,BookingId,RoomId")] RoomBooking roomBooking)
        {
            if (id != roomBooking.RoomBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomBookingExists(roomBooking.RoomBookingId))
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
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingId", roomBooking.BookingId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", roomBooking.RoomId);
            return View(roomBooking);
        }

        // GET: RoomBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBooking
                .Include(r => r.booking)
                .Include(r => r.room)
                .FirstOrDefaultAsync(m => m.RoomBookingId == id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            return View(roomBooking);
        }

        // POST: RoomBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomBooking = await _context.RoomBooking.FindAsync(id);
            if (roomBooking != null)
            {
                _context.RoomBooking.Remove(roomBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomBookingExists(int id)
        {
            return _context.RoomBooking.Any(e => e.RoomBookingId == id);
        }
    }
}
