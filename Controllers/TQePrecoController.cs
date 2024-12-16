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
    public class TQePrecoController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public TQePrecoController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: TQePreco
        public async Task<IActionResult> Index()
        {
            return View(await _context.TQePreco.ToListAsync());
        }

        // GET: TQePreco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tQePreco = await _context.TQePreco
                .FirstOrDefaultAsync(m => m.id_RTPrice == id);
            if (tQePreco == null)
            {
                return NotFound();
            }

            return View(tQePreco);
        }

        // GET: TQePreco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TQePreco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_RTPrice,type,capacity,RoomQuantity,AcessibilityRoom,View,BasePrice,CancelationFee,AdicionalBeds")] TQePreco tQePreco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tQePreco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tQePreco);
        }

        // GET: TQePreco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tQePreco = await _context.TQePreco.FindAsync(id);
            if (tQePreco == null)
            {
                return NotFound();
            }
            return View(tQePreco);
        }

        // POST: TQePreco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_RTPrice,type,capacity,RoomQuantity,AcessibilityRoom,View,BasePrice,CancelationFee,AdicionalBeds")] TQePreco tQePreco)
        {
            if (id != tQePreco.id_RTPrice)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tQePreco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TQePrecoExists(tQePreco.id_RTPrice))
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
            return View(tQePreco);
        }

        // GET: TQePreco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tQePreco = await _context.TQePreco
                .FirstOrDefaultAsync(m => m.id_RTPrice == id);
            if (tQePreco == null)
            {
                return NotFound();
            }

            return View(tQePreco);
        }

        // POST: TQePreco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tQePreco = await _context.TQePreco.FindAsync(id);
            if (tQePreco != null)
            {
                _context.TQePreco.Remove(tQePreco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TQePrecoExists(int id)
        {
            return _context.TQePreco.Any(e => e.id_RTPrice == id);
        }
    }
}
