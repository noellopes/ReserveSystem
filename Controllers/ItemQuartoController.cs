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
    public class ItemQuartoController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ItemQuartoController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ItemQuarto
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemQuarto.ToListAsync());
        }

        // GET: ItemQuarto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemQuarto = await _context.ItemQuarto
                .FirstOrDefaultAsync(m => m.ItemQuartoId == id);
            if (itemQuarto == null)
            {
                return NotFound();
            }

            return View(itemQuarto);
        }

        // GET: ItemQuarto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemQuarto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemQuartoId,QuantidadeQuarto")] ItemQuarto itemQuarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemQuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemQuarto);
        }

        // GET: ItemQuarto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemQuarto = await _context.ItemQuarto.FindAsync(id);
            if (itemQuarto == null)
            {
                return NotFound();
            }
            return View(itemQuarto);
        }

        // POST: ItemQuarto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemQuartoId,QuantidadeQuarto")] ItemQuarto itemQuarto)
        {
            if (id != itemQuarto.ItemQuartoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemQuarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemQuartoExists(itemQuarto.ItemQuartoId))
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
            return View(itemQuarto);
        }

        // GET: ItemQuarto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemQuarto = await _context.ItemQuarto
                .FirstOrDefaultAsync(m => m.ItemQuartoId == id);
            if (itemQuarto == null)
            {
                return NotFound();
            }

            return View(itemQuarto);
        }

        // POST: ItemQuarto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemQuarto = await _context.ItemQuarto.FindAsync(id);
            if (itemQuarto != null)
            {
                _context.ItemQuarto.Remove(itemQuarto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemQuartoExists(int id)
        {
            return _context.ItemQuarto.Any(e => e.ItemQuartoId == id);
        }
    }
}
