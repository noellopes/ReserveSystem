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
    public class TipoQuartoExemploController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public TipoQuartoExemploController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: TipoQuartoExemplo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoQuarto.ToListAsync());
        }

        // GET: TipoQuartoExemplo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuarto
                .FirstOrDefaultAsync(m => m.TipoQuartoId == id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }

            return View(tipoQuarto);
        }

        // GET: TipoQuartoExemplo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoQuartoExemplo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoQuartoId,type,capacity,RoomQuantity,AcessibilityRoom,View")] TipoQuarto tipoQuarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoQuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoQuarto);
        }

        // GET: TipoQuartoExemplo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuarto.FindAsync(id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }
            return View(tipoQuarto);
        }

        // POST: TipoQuartoExemplo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoQuartoId,type,capacity,RoomQuantity,AcessibilityRoom,View")] TipoQuarto tipoQuarto)
        {
            if (id != tipoQuarto.TipoQuartoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoQuarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoQuartoExists(tipoQuarto.TipoQuartoId))
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
            return View(tipoQuarto);
        }

        // GET: TipoQuartoExemplo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuarto = await _context.TipoQuarto
                .FirstOrDefaultAsync(m => m.TipoQuartoId == id);
            if (tipoQuarto == null)
            {
                return NotFound();
            }

            return View(tipoQuarto);
        }

        // POST: TipoQuartoExemplo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoQuarto = await _context.TipoQuarto.FindAsync(id);
            if (tipoQuarto != null)
            {
                _context.TipoQuarto.Remove(tipoQuarto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoQuartoExists(int id)
        {
            return _context.TipoQuarto.Any(e => e.TipoQuartoId == id);
        }
    }
}
