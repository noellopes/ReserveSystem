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
    public class CleaningShedulesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public CleaningShedulesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: CleaningShedules
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.CleaningShedule.Include(c => c.cleaning).Include(c => c.roomBooking).Include(c => c.staff);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: CleaningShedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaningShedule = await _context.CleaningShedule
                .Include(c => c.cleaning)
                .Include(c => c.roomBooking)
                .Include(c => c.staff)
                .FirstOrDefaultAsync(m => m.CleaningSheduleId == id);
            if (cleaningShedule == null)
            {
                return NotFound();
            }

            return View(cleaningShedule);
        }

        // GET: CleaningShedules/Create
        public IActionResult Create()
        {
            ViewData["CleaningId"] = new SelectList(_context.Cleaning, "CleaningId", "CleaningId");
            ViewData["RoomBookingId"] = new SelectList(_context.RoomBooking, "RoomBookingId", "RoomBookingId");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId");
            return View();
        }

        // POST: CleaningShedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CleaningSheduleId,DateServices,StartTime,EndTime,CleaningId,StaffId,RoomBookingId")] CleaningShedule cleaningShedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cleaningShedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CleaningId"] = new SelectList(_context.Cleaning, "CleaningId", "CleaningId", cleaningShedule.CleaningId);
            ViewData["RoomBookingId"] = new SelectList(_context.RoomBooking, "RoomBookingId", "RoomBookingId", cleaningShedule.RoomBookingId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", cleaningShedule.StaffId);
            return View(cleaningShedule);
        }

        // GET: CleaningShedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaningShedule = await _context.CleaningShedule.FindAsync(id);
            if (cleaningShedule == null)
            {
                return NotFound();
            }
            ViewData["CleaningId"] = new SelectList(_context.Cleaning, "CleaningId", "CleaningId", cleaningShedule.CleaningId);
            ViewData["RoomBookingId"] = new SelectList(_context.RoomBooking, "RoomBookingId", "RoomBookingId", cleaningShedule.RoomBookingId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", cleaningShedule.StaffId);
            return View(cleaningShedule);
        }

        // POST: CleaningShedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CleaningSheduleId,DateServices,StartTime,EndTime,CleaningId,StaffId,RoomBookingId")] CleaningShedule cleaningShedule)
        {
            if (id != cleaningShedule.CleaningSheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cleaningShedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CleaningSheduleExists(cleaningShedule.CleaningSheduleId))
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
            ViewData["CleaningId"] = new SelectList(_context.Cleaning, "CleaningId", "CleaningId", cleaningShedule.CleaningId);
            ViewData["RoomBookingId"] = new SelectList(_context.RoomBooking, "RoomBookingId", "RoomBookingId", cleaningShedule.RoomBookingId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", cleaningShedule.StaffId);
            return View(cleaningShedule);
        }

        // GET: CleaningShedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaningShedule = await _context.CleaningShedule
                .Include(c => c.cleaning)
                .Include(c => c.roomBooking)
                .Include(c => c.staff)
                .FirstOrDefaultAsync(m => m.CleaningSheduleId == id);
            if (cleaningShedule == null)
            {
                return NotFound();
            }

            return View(cleaningShedule);
        }

        // POST: CleaningShedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cleaningShedule = await _context.CleaningShedule.FindAsync(id);
            if (cleaningShedule != null)
            {
                _context.CleaningShedule.Remove(cleaningShedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CleaningSheduleExists(int id)
        {
            return _context.CleaningShedule.Any(e => e.CleaningSheduleId == id);
        }
    }
}
