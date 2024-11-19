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
    public class RoomServicesBookingsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomServicesBookingsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomServicesBookings
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.RoomServiceBooking.Include(r => r.Client).Include(r => r.Room).Include(r => r.RoomService).Include(r => r.Staff);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: RoomServicesBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServicesBooking = await _context.RoomServiceBooking
                .Include(r => r.Client)
                .Include(r => r.Room)
                .Include(r => r.RoomService)
                .Include(r => r.Staff)
                .FirstOrDefaultAsync(m => m.RoomServicesBookingID == id);
            if (roomServicesBooking == null)
            {
                return NotFound();
            }

            return View(roomServicesBooking);
        }

        // GET: RoomServicesBookings/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ClientID", "ClientID");
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "RoomID", "RoomID");
            ViewData["RoomServiceID"] = new SelectList(_context.Set<RoomService>(), "RoomServiceID", "RoomServiceID");
            ViewData["StaffID"] = new SelectList(_context.Set<Staff>(), "StaffID", "StaffID");
            return View();
        }

        // POST: RoomServicesBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomServicesBookingID,RoomServiceID,StaffID,ClientID,RoomID,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,AmountToPay,PaymentMade")] RoomServicesBooking roomServicesBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomServicesBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ClientID", "ClientID", roomServicesBooking.ClientID);
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "RoomID", "RoomID", roomServicesBooking.RoomID);
            ViewData["RoomServiceID"] = new SelectList(_context.Set<RoomService>(), "RoomServiceID", "RoomServiceID", roomServicesBooking.RoomServiceID);
            ViewData["StaffID"] = new SelectList(_context.Set<Staff>(), "StaffID", "StaffID", roomServicesBooking.StaffID);
            return View(roomServicesBooking);
        }

        // GET: RoomServicesBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServicesBooking = await _context.RoomServiceBooking.FindAsync(id);
            if (roomServicesBooking == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ClientID", "ClientID", roomServicesBooking.ClientID);
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "RoomID", "RoomID", roomServicesBooking.RoomID);
            ViewData["RoomServiceID"] = new SelectList(_context.Set<RoomService>(), "RoomServiceID", "RoomServiceID", roomServicesBooking.RoomServiceID);
            ViewData["StaffID"] = new SelectList(_context.Set<Staff>(), "StaffID", "StaffID", roomServicesBooking.StaffID);
            return View(roomServicesBooking);
        }

        // POST: RoomServicesBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomServicesBookingID,RoomServiceID,StaffID,ClientID,RoomID,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,AmountToPay,PaymentMade")] RoomServicesBooking roomServicesBooking)
        {
            if (id != roomServicesBooking.RoomServicesBookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomServicesBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServicesBookingExists(roomServicesBooking.RoomServicesBookingID))
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
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ClientID", "ClientID", roomServicesBooking.ClientID);
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "RoomID", "RoomID", roomServicesBooking.RoomID);
            ViewData["RoomServiceID"] = new SelectList(_context.Set<RoomService>(), "RoomServiceID", "RoomServiceID", roomServicesBooking.RoomServiceID);
            ViewData["StaffID"] = new SelectList(_context.Set<Staff>(), "StaffID", "StaffID", roomServicesBooking.StaffID);
            return View(roomServicesBooking);
        }

        // GET: RoomServicesBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServicesBooking = await _context.RoomServiceBooking
                .Include(r => r.Client)
                .Include(r => r.Room)
                .Include(r => r.RoomService)
                .Include(r => r.Staff)
                .FirstOrDefaultAsync(m => m.RoomServicesBookingID == id);
            if (roomServicesBooking == null)
            {
                return NotFound();
            }

            return View(roomServicesBooking);
        }

        // POST: RoomServicesBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomServicesBooking = await _context.RoomServiceBooking.FindAsync(id);
            if (roomServicesBooking != null)
            {
                _context.RoomServiceBooking.Remove(roomServicesBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomServicesBookingExists(int id)
        {
            return _context.RoomServiceBooking.Any(e => e.RoomServicesBookingID == id);
        }
    }
}
