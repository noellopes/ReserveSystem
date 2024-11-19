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
    public class PrecoTipoQController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public PrecoTipoQController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: PrecoTipoQ
        public async Task<IActionResult> Index()
        {
            var reserveSystemUsersDbContext = _context.PrecoTipoQuarto.Include(p => p.TipoQuarto);
            return View(await reserveSystemUsersDbContext.ToListAsync());
        }

        // GET: PrecoTipoQ/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precoTipoQuarto = await _context.PrecoTipoQuarto
                .Include(p => p.TipoQuarto)
                .FirstOrDefaultAsync(m => m.id_RTPrice == id);
            if (precoTipoQuarto == null)
            {
                return NotFound();
            }

            return View(precoTipoQuarto);
        }

        // GET: PrecoTipoQ/Create
        public IActionResult Create()
        {
            ViewData["TipoQuartoId"] = new SelectList(_context.TipoQuarto, "TipoQuartoId", "type");
            return View();
        }

        // POST: PrecoTipoQ/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_RTPrice,BasePrice,CancelationFee,AdicionalBeds,TipoQuartoId")] PrecoTipoQuarto precoTipoQuarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precoTipoQuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoQuartoId"] = new SelectList(_context.TipoQuarto, "TipoQuartoId", "type", precoTipoQuarto.TipoQuartoId);
            return View(precoTipoQuarto);
        }

        // GET: PrecoTipoQ/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precoTipoQuarto = await _context.PrecoTipoQuarto.FindAsync(id);
            if (precoTipoQuarto == null)
            {
                return NotFound();
            }
            ViewData["TipoQuartoId"] = new SelectList(_context.TipoQuarto, "TipoQuartoId", "type", precoTipoQuarto.TipoQuartoId);
            return View(precoTipoQuarto);
        }

        // POST: PrecoTipoQ/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_RTPrice,BasePrice,CancelationFee,AdicionalBeds,TipoQuartoId")] PrecoTipoQuarto precoTipoQuarto)
        {
            if (id != precoTipoQuarto.id_RTPrice)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precoTipoQuarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecoTipoQuartoExists(precoTipoQuarto.id_RTPrice))
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
            ViewData["TipoQuartoId"] = new SelectList(_context.TipoQuarto, "TipoQuartoId", "type", precoTipoQuarto.TipoQuartoId);
            return View(precoTipoQuarto);
        }

        // GET: PrecoTipoQ/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precoTipoQuarto = await _context.PrecoTipoQuarto
                .Include(p => p.TipoQuarto)
                .FirstOrDefaultAsync(m => m.id_RTPrice == id);
            if (precoTipoQuarto == null)
            {
                return NotFound();
            }

            return View(precoTipoQuarto);
        }

        // POST: PrecoTipoQ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var precoTipoQuarto = await _context.PrecoTipoQuarto.FindAsync(id);
            if (precoTipoQuarto != null)
            {
                _context.PrecoTipoQuarto.Remove(precoTipoQuarto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecoTipoQuartoExists(int id)
        {
            return _context.PrecoTipoQuarto.Any(e => e.id_RTPrice == id);
        }
    }
}
