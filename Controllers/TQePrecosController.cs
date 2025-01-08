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
    public class TQePrecosController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public TQePrecosController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: TQePrecos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TQePreco.ToListAsync());
        }

        // GET: TQePrecos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tQePreco = await _context.TQePreco
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (tQePreco == null)
            {
                return NotFound();
            }

            return View(tQePreco);
        }

        // GET: TQePrecos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TQePrecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomTypeId,type,capacity,RoomQuantity,AcessibilityRoom,View,BasePrice,AdicionalBeds,InUse")] TQePreco tQePreco)
        {
            bool RtypeExists = await _context.TQePreco.AnyAsync(e  => e.type == tQePreco.type);
            if (RtypeExists)
            {
                ModelState.AddModelError("type", "A room type with this name already exists");
            }
            if (ModelState.IsValid)
            {
                _context.Add(tQePreco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tQePreco);
        }

        // GET: TQePrecos/Edit/5
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

        // POST: TQePrecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomTypeId,type,capacity,RoomQuantity,AcessibilityRoom,View,BasePrice,AdicionalBeds,InUse")] TQePreco tQePreco)
        {
            if (id != tQePreco.RoomTypeId)
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
                    if (!TQePrecoExists(tQePreco.RoomTypeId))
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

        // GET: TQePrecos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tQePreco = await _context.TQePreco
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (tQePreco == null)
            {
                return NotFound();
            }

            return View(tQePreco);
        }

        // POST: TQePrecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tQePreco = await _context.TQePreco.FindAsync(id);
            if (tQePreco != null)
            {
                tQePreco.InUse = false;
                //_context.TQePreco.Remove(tQePreco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TQePrecoExists(int id)
        {
            return _context.TQePreco.Any(e => e.RoomTypeId == id);
        }
    }
}
