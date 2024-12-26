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
    public class SchedulesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public SchedulesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.Schedules.Include(s => s.staff).Include(s => s.typeOfSchedule);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules
                .Include(s => s.staff)
                .Include(s => s.typeOfSchedule)
                .FirstOrDefaultAsync(m => m.SchedulesId == id);
            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense");
            ViewData["TypeOfScheduleId"] = new SelectList(_context.Set<TypeOfSchedule>(), "TypeOfScheduleId", "JobDescription");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchedulesId,StartShiftTime,EndShiftTime,isPrecense,isAvailable,StaffId,TypeOfScheduleId")] Schedules schedules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", schedules.StaffId);
            ViewData["TypeOfScheduleId"] = new SelectList(_context.Set<TypeOfSchedule>(), "TypeOfScheduleId", "JobDescription", schedules.TypeOfScheduleId);
            return View(schedules);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules.FindAsync(id);
            if (schedules == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", schedules.StaffId);
            ViewData["TypeOfScheduleId"] = new SelectList(_context.Set<TypeOfSchedule>(), "TypeOfScheduleId", "JobDescription", schedules.TypeOfScheduleId);
            return View(schedules);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchedulesId,StartShiftTime,EndShiftTime,isPrecense,isAvailable,StaffId,TypeOfScheduleId")] Schedules schedules)
        {
            if (id != schedules.SchedulesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulesExists(schedules.SchedulesId))
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
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", schedules.StaffId);
            ViewData["TypeOfScheduleId"] = new SelectList(_context.Set<TypeOfSchedule>(), "TypeOfScheduleId", "JobDescription", schedules.TypeOfScheduleId);
            return View(schedules);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules
                .Include(s => s.staff)
                .Include(s => s.typeOfSchedule)
                .FirstOrDefaultAsync(m => m.SchedulesId == id);
            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedules = await _context.Schedules.FindAsync(id);
            if (schedules != null)
            {
                _context.Schedules.Remove(schedules);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchedulesExists(int id)
        {
            return _context.Schedules.Any(e => e.SchedulesId == id);
        }
    }
}
