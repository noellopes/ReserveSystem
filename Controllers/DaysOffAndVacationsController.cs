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
    public class DaysOffAndVacationsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public DaysOffAndVacationsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: DaysOffAndVacations
        public async Task<IActionResult> Index()
        {
            return View(await _context.DaysOffAndVacations.ToListAsync());
        }

        // GET: DaysOffAndVacations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysOffAndVacations = await _context.DaysOffAndVacations
                .FirstOrDefaultAsync(m => m.DayOffVacationId == id);
            if (daysOffAndVacations == null)
            {
                return NotFound();
            }

            return View(daysOffAndVacations);
        }

        // GET: DaysOffAndVacations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DaysOffAndVacations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DayOffVacationId,StaffId,StartDate,EndDate,Reason,Status")] DaysOffAndVacations daysOffAndVacations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daysOffAndVacations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daysOffAndVacations);
        }

        // GET: DaysOffAndVacations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysOffAndVacations = await _context.DaysOffAndVacations.FindAsync(id);
            if (daysOffAndVacations == null)
            {
                return NotFound();
            }
            return View(daysOffAndVacations);
        }

        // POST: DaysOffAndVacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DayOffVacationId,StaffId,StartDate,EndDate,Reason,Status")] DaysOffAndVacations daysOffAndVacations)
        {
            if (id != daysOffAndVacations.DayOffVacationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daysOffAndVacations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaysOffAndVacationsExists(daysOffAndVacations.DayOffVacationId))
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
            return View(daysOffAndVacations);
        }

        // GET: DaysOffAndVacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysOffAndVacations = await _context.DaysOffAndVacations
                .FirstOrDefaultAsync(m => m.DayOffVacationId == id);
            if (daysOffAndVacations == null)
            {
                return NotFound();
            }

            return View(daysOffAndVacations);
        }

        // POST: DaysOffAndVacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daysOffAndVacations = await _context.DaysOffAndVacations.FindAsync(id);
            if (daysOffAndVacations != null)
            {
                _context.DaysOffAndVacations.Remove(daysOffAndVacations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaysOffAndVacationsExists(int id)
        {
            return _context.DaysOffAndVacations.Any(e => e.DayOffVacationId == id);
        }
    }
}
