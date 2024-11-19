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
    public class RoomServicesBookingController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomServicesBookingController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomServicesBooking
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.RoomServiceBooking.Include(r => r.Client).Include(r => r.Room).Include(r => r.RoomService).Include(r => r.Staff);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: RoomServicesBooking/Details/5
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
                .FirstOrDefaultAsync(m => m.RoomServiceBookingId == id);
            if (roomServicesBooking == null)
            {
                return NotFound();
            }

            return View(roomServicesBooking);
        }

        // GET: RoomServicesBooking/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ClientId", "ClientId");
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "RoomId");
            ViewData["RoomServiceId"] = new SelectList(_context.Set<RoomService>(), "RoomServiceId", "RoomServiceId");
            ViewData["StaffId"] = new SelectList(_context.Set<Staff>(), "StaffId", "StaffId");
            return View();
        }

        // POST: RoomServicesBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomServiceBookingId,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,AmountToPay,PaymentMade")] RoomServicesBooking roomServicesBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomServicesBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ClientId", "ClientId", roomServicesBooking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "RoomId", roomServicesBooking.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.Set<RoomService>(), "RoomServiceId", "RoomServiceId", roomServicesBooking.RoomServiceId);
            ViewData["StaffId"] = new SelectList(_context.Set<Staff>(), "StaffId", "StaffId", roomServicesBooking.StaffId);
            return View(roomServicesBooking);
        }

        // GET: RoomServicesBooking/Edit/5
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
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ClientId", "ClientId", roomServicesBooking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "RoomId", roomServicesBooking.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.Set<RoomService>(), "RoomServiceId", "RoomServiceId", roomServicesBooking.RoomServiceId);
            ViewData["StaffId"] = new SelectList(_context.Set<Staff>(), "StaffId", "StaffId", roomServicesBooking.StaffId);
            return View(roomServicesBooking);
        }

        // POST: RoomServicesBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomServiceBookingId,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,AmountToPay,PaymentMade")] RoomServicesBooking roomServicesBooking)
        {
            if (id != roomServicesBooking.RoomServiceBookingId)
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
                    if (!RoomServicesBookingExists(roomServicesBooking.RoomServiceBookingId))
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
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ClientId", "ClientId", roomServicesBooking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "RoomId", roomServicesBooking.RoomId);
            ViewData["RoomServiceId"] = new SelectList(_context.Set<RoomService>(), "RoomServiceId", "RoomServiceId", roomServicesBooking.RoomServiceId);
            ViewData["StaffId"] = new SelectList(_context.Set<Staff>(), "StaffId", "StaffId", roomServicesBooking.StaffId);
            return View(roomServicesBooking);
        }

        // GET: RoomServicesBooking/Delete/5
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
                .FirstOrDefaultAsync(m => m.RoomServiceBookingId == id);
            if (roomServicesBooking == null)
            {
                return NotFound();
            }

            return View(roomServicesBooking);
        }

        // POST: RoomServicesBooking/Delete/5
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
            return _context.RoomServiceBooking.Any(e => e.RoomServiceBookingId == id);
        }
    }
}
