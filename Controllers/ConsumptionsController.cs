using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
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
            return View(await _context.Consumptions.ToListAsync());
        }

        // GET: Consumptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptions = await _context.Consumptions
                .FirstOrDefaultAsync(m => m.ConsumptionId == id);
            if (consumptions == null)
            {
                return NotFound();
            }

            return View(consumptions);
        }

        // GET: Consumptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consumptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumptionId,RoomId,ItemId,QuantityConsumed,ConsumedDate")] Consumptions consumptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumptions);
        }

        public IActionResult RegistrationSuccess(Consumptions consumption)
        {
            return View(consumption);
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
            return View(consumptions);
        }

        // POST: Consumptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumptionId,RoomId,ItemId,QuantityConsumed,ConsumedDate")] Consumptions consumptions)
        {
            if (id != consumptions.ConsumptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumptions);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("EditSuccess", new { consumptionId = consumptions.ConsumptionId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumptionExists(consumptions.ConsumptionId))
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
            return View(consumptions);
        }
        // GET: Consumptions/EditSuccess
        public async Task<IActionResult> EditSuccess(int consumptionId)
        {
            var consumption = await _context.Consumptions
                .Include(c => c.room)
                .Include(c => c.items)
                .FirstOrDefaultAsync(c => c.ConsumptionId == consumptionId);

            if (consumption == null)
            {
                return NotFound();
            }

            // Mensagem de sucesso
            ViewBag.Message = "Consumption edited successfully!";
            return View(consumption);
        }

        // GET: Consumptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumptions = await _context.Consumptions
                .FirstOrDefaultAsync(m => m.ConsumptionId == id);
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
    var consumption = await _context.Consumptions
        .Include(c => c.room)
        .Include(c => c.items)
        .FirstOrDefaultAsync(c => c.ConsumptionId == id);

    if (consumption != null)
    {
        _context.Consumptions.Remove(consumption);
        await _context.SaveChangesAsync();
    }

    // Redireciona para a página de confirmação de exclusão
    return RedirectToAction("DeleteSuccess", new 
    { 
        itemName = consumption?.items?.Name, 
        consumedDate = consumption?.ConsumedDate.ToString("yyyy-MM-dd") 
    });
}

// GET: Consumptions/DeleteSuccess
public IActionResult DeleteSuccess(string itemName, string roomName, string consumedDate)
{
    ViewBag.ItemName = itemName;
    ViewBag.RoomName = roomName;
    ViewBag.ConsumedDate = consumedDate;
    return View();
}

private bool ConsumptionExists(int id)
{
    return _context.Consumptions.Any(e => e.ConsumptionId == id);
}

    }
}

