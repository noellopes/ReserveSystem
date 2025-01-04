using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class Room_BookingController : Controller
    {
        private readonly ReserveSystemContext _context;

        public Room_BookingController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Room_Booking
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room_Booking.ToListAsync());
        }

        // GET: Room_Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Booking = await _context.Room_Booking
                .FirstOrDefaultAsync(m => m.RoomBookingId == id);
            if (room_Booking == null)
            {
                return NotFound();
            }

            return View(room_Booking);
        }

        // GET: Room_Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room_Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomBookingId,BookingId,RoomId,Persons_Number")] Room_Booking room_Booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room_Booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room_Booking);
        }

        // GET: Room_Booking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Booking = await _context.Room_Booking.FindAsync(id);
            if (room_Booking == null)
            {
                return NotFound();
            }
            return View(room_Booking);
        }

        // POST: Room_Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomBookingId,BookingId,RoomId,Persons_Number")] Room_Booking room_Booking)
        {
            if (id != room_Booking.RoomBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room_Booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Room_BookingExists(room_Booking.RoomBookingId))
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
            return View(room_Booking);
        }

        // GET: Room_Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Booking = await _context.Room_Booking
                .FirstOrDefaultAsync(m => m.RoomBookingId == id);
            if (room_Booking == null)
            {
                return NotFound();
            }

            return View(room_Booking);
        }

        // POST: Room_Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room_Booking = await _context.Room_Booking.FindAsync(id);
            if (room_Booking != null)
            {
                _context.Room_Booking.Remove(room_Booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Room_BookingExists(int id)
        {
            return _context.Room_Booking.Any(e => e.RoomBookingId == id);
        }
    }
}
