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
    public class DepModelsController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public DepModelsController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: DepModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DepModel.ToListAsync());
        }

        // GET: DepModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depModel = await _context.DepModel
                .FirstOrDefaultAsync(m => m.depID == id);
            if (depModel == null)
            {
                return NotFound();
            }

            return View(depModel);
        }

        // GET: DepModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("depID,depDescription")] DepModel depModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(depModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(depModel);
        }

        // GET: DepModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depModel = await _context.DepModel.FindAsync(id);
            if (depModel == null)
            {
                return NotFound();
            }
            return View(depModel);
        }

        // POST: DepModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("depID,depDescription")] DepModel depModel)
        {
            if (id != depModel.depID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepModelExists(depModel.depID))
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
            return View(depModel);
        }

        // GET: DepModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depModel = await _context.DepModel
                .FirstOrDefaultAsync(m => m.depID == id);
            if (depModel == null)
            {
                return NotFound();
            }

            return View(depModel);
        }

        // POST: DepModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var depModel = await _context.DepModel.FindAsync(id);
            if (depModel != null)
            {
                _context.DepModel.Remove(depModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepModelExists(int id)
        {
            return _context.DepModel.Any(e => e.depID == id);
        }
    }
}
