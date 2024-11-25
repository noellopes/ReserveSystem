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
    public class ConsumptionsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ConsumptionsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Consumptions
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.Consumptions.Include(c => c.client).Include(c => c.itemRoom);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: Consumptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptions = await _context.Consumptions
                .Include(c => c.client)
                .Include(c => c.itemRoom)
                .FirstOrDefaultAsync(m => m.ConsumptionsId == id);
            if (consumptions == null)
            {
                return NotFound();
            }

            return View(consumptions);
        }

        // GET: Consumptions/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientId");
            ViewData["ItemRoomId"] = new SelectList(_context.Set<ItemRoom>(), "ItemRoomId", "ItemRoomId");
            return View();
        }

        // POST: Consumptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumptionsId,ItemRoomId,QuantityConsumed,ConsumedDate,ClientId")] Consumptions consumptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientId", consumptions.ClientId);
            ViewData["ItemRoomId"] = new SelectList(_context.Set<ItemRoom>(), "ItemRoomId", "ItemRoomId", consumptions.ItemRoomId);
            return View(consumptions);
        }

        // GET: Consumptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptions = await _context.Consumptions.FindAsync(id);
            if (consumptions == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientId", consumptions.ClientId);
            ViewData["ItemRoomId"] = new SelectList(_context.Set<ItemRoom>(), "ItemRoomId", "ItemRoomId", consumptions.ItemRoomId);
            return View(consumptions);
        }

        // POST: Consumptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumptionsId,ItemRoomId,QuantityConsumed,ConsumedDate,ClientId")] Consumptions consumptions)
        {
            if (id != consumptions.ConsumptionsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumptionsExists(consumptions.ConsumptionsId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientId", consumptions.ClientId);
            ViewData["ItemRoomId"] = new SelectList(_context.Set<ItemRoom>(), "ItemRoomId", "ItemRoomId", consumptions.ItemRoomId);
            return View(consumptions);
        }

        // GET: Consumptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptions = await _context.Consumptions
                .Include(c => c.client)
                .Include(c => c.itemRoom)
                .FirstOrDefaultAsync(m => m.ConsumptionsId == id);
            if (consumptions == null)
            {
                return NotFound();
            }

            return View(consumptions);
        }

        // POST: Consumptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumptions = await _context.Consumptions.FindAsync(id);
            if (consumptions != null)
            {
                _context.Consumptions.Remove(consumptions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumptionsExists(int id)
        {
            return _context.Consumptions.Any(e => e.ConsumptionsId == id);
        }
    }
}
