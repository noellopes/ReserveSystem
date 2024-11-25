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
    public class CleaningsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public CleaningsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Cleanings
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.Cleaning.Include(c => c.room);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: Cleanings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaning = await _context.Cleaning
                .Include(c => c.room)
                .FirstOrDefaultAsync(m => m.CleaningId == id);
            if (cleaning == null)
            {
                return NotFound();
            }

            return View(cleaning);
        }

        // GET: Cleanings/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "RoomId");
            return View();
        }

        // POST: Cleanings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CleaningId,CleaningService,RoomId")] Cleaning cleaning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cleaning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "RoomId", cleaning.RoomId);
            return View(cleaning);
        }

        // GET: Cleanings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaning = await _context.Cleaning.FindAsync(id);
            if (cleaning == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "RoomId", cleaning.RoomId);
            return View(cleaning);
        }

        // POST: Cleanings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CleaningId,CleaningService,RoomId")] Cleaning cleaning)
        {
            if (id != cleaning.CleaningId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cleaning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CleaningExists(cleaning.CleaningId))
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
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "RoomId", "RoomId", cleaning.RoomId);
            return View(cleaning);
        }

        // GET: Cleanings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaning = await _context.Cleaning
                .Include(c => c.room)
                .FirstOrDefaultAsync(m => m.CleaningId == id);
            if (cleaning == null)
            {
                return NotFound();
            }

            return View(cleaning);
        }

        // POST: Cleanings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cleaning = await _context.Cleaning.FindAsync(id);
            if (cleaning != null)
            {
                _context.Cleaning.Remove(cleaning);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CleaningExists(int id)
        {
            return _context.Cleaning.Any(e => e.CleaningId == id);
        }
    }
}
