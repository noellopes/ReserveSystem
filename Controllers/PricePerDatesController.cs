using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    
    public class PricePerDatesController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public PricePerDatesController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "User")]
        // GET: PricePerDates
        public async Task<IActionResult> Index()
        {
            var pricePerDateList = await _context.PricePerDate
                .Include(p => p.TQePreco)
                .ToListAsync();

            var allEvents = await _context.Events.Where(e => e.inUse).ToListAsync();
            var allSazonalidades = await _context.Sazonalidade.Where(s => s.InUse).ToListAsync();

            foreach (var pricePerDate in pricePerDateList)
            {
                pricePerDate.Events = allEvents.Where(e => e.startDate.AddDays(-7) <= pricePerDate.dateEnd &&
                                                           e.endDate >= pricePerDate.dateBegin).ToList();

                pricePerDate.Sazonalidades = allSazonalidades.Where(s => s.DateBegin.AddDays(-7) <= pricePerDate.dateEnd &&
                                                                         s.DateEnd >= pricePerDate.dateBegin).ToList();

                pricePerDate.CalculateNewPrice();
            }

            return View(pricePerDateList);
        }
        [Authorize(Roles = "Admin")]
        // GET: PricePerDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var pricePerDate = await _context.PricePerDate
                .Include(p => p.TQePreco)
                .FirstOrDefaultAsync(m => m.pricePD_id == id);

            if (pricePerDate == null)
                return NotFound();

            var allEvents = await _context.Events.Where(e => e.inUse).ToListAsync();
            var allSazonalidades = await _context.Sazonalidade.Where(s => s.InUse).ToListAsync();

            pricePerDate.Events = allEvents.Where(e => e.startDate.AddDays(-7) <= pricePerDate.dateEnd &&
                                                       e.endDate >= pricePerDate.dateBegin).ToList();

            pricePerDate.Sazonalidades = allSazonalidades.Where(s => s.DateBegin.AddDays(-7) <= pricePerDate.dateEnd &&
                                                                     s.DateEnd >= pricePerDate.dateBegin).ToList();

            pricePerDate.CalculateNewPrice();

            return View(pricePerDate);
        }

// GET: PricePerDates/Create
    public IActionResult Create()
        {
            ViewData["RoomTypeId"] = new SelectList(_context.TQePreco, "RoomTypeId", "type");
            return View();
        }

        // POST: PricePerDates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pricePD_id,RoomTypeId,dateBegin,dateEnd,newPricePerDate,actState")] PricePerDate pricePerDate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pricePerDate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomTypeId"] = new SelectList(_context.TQePreco, "RoomTypeId", "type", pricePerDate.RoomTypeId);
            return View(pricePerDate);
        }

        // GET: PricePerDates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricePerDate = await _context.PricePerDate.FindAsync(id);
            if (pricePerDate == null)
            {
                return NotFound();
            }

            ViewData["RoomTypeId"] = new SelectList(_context.TQePreco, "RoomTypeId", "type", pricePerDate.RoomTypeId);
            return View(pricePerDate);
        }

        // POST: PricePerDates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pricePD_id,RoomTypeId,dateBegin,dateEnd,newPricePerDate,actState")] PricePerDate pricePerDate)
        {
            if (id != pricePerDate.pricePD_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pricePerDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PricePerDateExists(pricePerDate.pricePD_id))
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

            ViewData["RoomTypeId"] = new SelectList(_context.TQePreco, "RoomTypeId", "type", pricePerDate.RoomTypeId);
            return View(pricePerDate);
        }

        // GET: PricePerDates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricePerDate = await _context.PricePerDate
                .Include(p => p.TQePreco)
                .FirstOrDefaultAsync(m => m.pricePD_id == id);

            if (pricePerDate == null)
            {
                return NotFound();
            }

            return View(pricePerDate);
        }

        // POST: PricePerDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pricePerDate = await _context.PricePerDate.FindAsync(id);
            if (pricePerDate != null)
            {
                _context.PricePerDate.Remove(pricePerDate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PricePerDateExists(int id)
        {
            return _context.PricePerDate.Any(e => e.pricePD_id == id);
        }
    }
}

