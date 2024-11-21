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
    public class QuartosController : Controller
    {
        private readonly ReserveSystemContext _context;

        public QuartosController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Quartos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quarto.ToListAsync());
        }

        // GET: Quartos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quarto
                .FirstOrDefaultAsync(m => m.QuartoId == id);
            if (quarto == null)
            {
                return NotFound();
            }

            return View(quarto);
        }

        // GET: Quartos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quartos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuartoId")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quarto);
        }

        // GET: Quartos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quarto.FindAsync(id);
            if (quarto == null)
            {
                return NotFound();
            }
            return View(quarto);
        }

        // POST: Quartos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuartoId")] Quarto quarto)
        {
            if (id != quarto.QuartoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuartoExists(quarto.QuartoId))
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
            return View(quarto);
        }

        // GET: Quartos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quarto
                .FirstOrDefaultAsync(m => m.QuartoId == id);
            if (quarto == null)
            {
                return NotFound();
            }

            return View(quarto);
        }

        // POST: Quartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quarto = await _context.Quarto.FindAsync(id);
            if (quarto != null)
            {
                _context.Quarto.Remove(quarto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuartoExists(int id)
        {
            return _context.Quarto.Any(e => e.QuartoId == id);
        }
    }
}
