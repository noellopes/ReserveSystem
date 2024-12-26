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
    public class TypeOfSchedulesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public TypeOfSchedulesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: TypeOfSchedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOfSchedule.ToListAsync());
        }

        // GET: TypeOfSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfSchedule = await _context.TypeOfSchedule
                .FirstOrDefaultAsync(m => m.TypeOfScheduleId == id);
            if (typeOfSchedule == null)
            {
                return NotFound();
            }

            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfScheduleId,TypeOfScheduleName,JobDescription")] TypeOfSchedule typeOfSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfSchedule = await _context.TypeOfSchedule.FindAsync(id);
            if (typeOfSchedule == null)
            {
                return NotFound();
            }
            return View(typeOfSchedule);
        }

        // POST: TypeOfSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeOfScheduleId,TypeOfScheduleName,JobDescription")] TypeOfSchedule typeOfSchedule)
        {
            if (id != typeOfSchedule.TypeOfScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfScheduleExists(typeOfSchedule.TypeOfScheduleId))
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
            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfSchedule = await _context.TypeOfSchedule
                .FirstOrDefaultAsync(m => m.TypeOfScheduleId == id);
            if (typeOfSchedule == null)
            {
                return NotFound();
            }

            return View(typeOfSchedule);
        }

        // POST: TypeOfSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfSchedule = await _context.TypeOfSchedule.FindAsync(id);
            if (typeOfSchedule != null)
            {
                _context.TypeOfSchedule.Remove(typeOfSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfScheduleExists(int id)
        {
            return _context.TypeOfSchedule.Any(e => e.TypeOfScheduleId == id);
        }
    }
}
