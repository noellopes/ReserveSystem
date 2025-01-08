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
    public class Cleaning_ScheduleController : Controller
    {
        private readonly ReserveSystemContext _context;

        public Cleaning_ScheduleController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Cleaning_Schedule
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.Cleaning_Schedule.Include(c => c.client).Include(c => c.staffMembers);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: Cleaning_Schedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaning_Schedule = await _context.Cleaning_Schedule
                .Include(c => c.client)
                .Include(c => c.staffMembers)
                .FirstOrDefaultAsync(m => m.CleaningScheduleId == id);
            if (cleaning_Schedule == null)
            {
                return NotFound();
            }

            return View(cleaning_Schedule);
        }

        // GET: Cleaning_Schedule/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense");
            return View();
        }

        // POST: Cleaning_Schedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CleaningScheduleId,RoomBookingId,ClientId,StaffId,DateServices,StartTime,EndTime,CleaningDone")] Cleaning_Schedule cleaning_Schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cleaning_Schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RegisterComplete), new { id = cleaning_Schedule.CleaningScheduleId });
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress", cleaning_Schedule.ClientId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", cleaning_Schedule.StaffId);
            return View(cleaning_Schedule);
        }

        public async Task<IActionResult>RegisterComplete(int id)
        {
            var cleaning_Schedule = await _context.Cleaning_Schedule
                .Include(c => c.client)
                .Include(c => c.staffMembers)
                .FirstOrDefaultAsync(m => m.CleaningScheduleId == id);

            if (cleaning_Schedule == null)
            {
                return NotFound();
            }

            return View(cleaning_Schedule);
        }

        // GET: Cleaning_Schedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaning_Schedule = await _context.Cleaning_Schedule.FindAsync(id);
            if (cleaning_Schedule == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress", cleaning_Schedule.ClientId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", cleaning_Schedule.StaffId);
            return View(cleaning_Schedule);
        }

        // POST: Cleaning_Schedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CleaningScheduleId,RoomBookingId,ClientId,StaffId,DateServices,StartTime,EndTime,CleaningDone")] Cleaning_Schedule cleaning_Schedule)
        {
            if (id != cleaning_Schedule.CleaningScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cleaning_Schedule);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("EditSuccess", new { cleaningScheduleId =cleaning_Schedule.CleaningScheduleId });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cleaning_ScheduleExists(cleaning_Schedule.CleaningScheduleId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress", cleaning_Schedule.ClientId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", cleaning_Schedule.StaffId);
            return View(cleaning_Schedule);
        }
        // GET: CleaningSchedule/EditSuccess
        public async Task<IActionResult> EditSuccess(int cleaningScheduleId)
        {
            var cleaningSchedule = await _context.Cleaning_Schedule
                .Include(cs => cs.staffMembers)
                .Include(cs => cs.room_Booking)
                .Include(cs => cs.client)
                .FirstOrDefaultAsync(cs => cs.CleaningScheduleId == cleaningScheduleId);

            if (cleaningSchedule == null)
            {
                return NotFound();
            }

            // Mensagem de sucesso
            ViewBag.Message = "Cleaning Schedule edited successfully!";
            return View(cleaningSchedule);
        }

        // GET: Cleaning_Schedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaning_Schedule = await _context.Cleaning_Schedule
                .Include(c => c.client)
                .Include(c => c.staffMembers)
                .FirstOrDefaultAsync(m => m.CleaningScheduleId == id);
            if (cleaning_Schedule == null)
            {
                return NotFound();
            }

            return View(cleaning_Schedule);
        }

        // POST: Cleaning_Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cleaning_Schedule = await _context.Cleaning_Schedule.FindAsync(id);
            if (cleaning_Schedule != null)
            {
                _context.Cleaning_Schedule.Remove(cleaning_Schedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cleaning_ScheduleExists(int id)
        {
            return _context.Cleaning_Schedule.Any(e => e.CleaningScheduleId == id);
        }
    }
}
