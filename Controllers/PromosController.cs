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
    public class PromosController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public PromosController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: Promos
        public async Task<IActionResult> Index(string searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<Promos> query = _context.Promos.Include(p => p.Events);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.evCode.Contains(searchTerm));
            }

            var totalItems = await query.CountAsync();

            var promos = await query
                .OrderBy(p => p.evCode)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.TotalItems = totalItems;
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;

            return View(promos);
        }





        // GET: Promos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promos = await _context.Promos
                .FirstOrDefaultAsync(m => m.Id_Prom == id);
            if (promos == null)
            {
                return NotFound();
            }

            return View(promos);
        }

        // GET: Promos/Create
        public IActionResult Create()
        {
            var events = _context.Events
                .Where(e => e.inUse)
                .Select(e => new { e.event_id, e.nameEv })
                .ToList();

            ViewBag.Events = new SelectList(events, "event_id", "nameEv");
            return View();
        }


        // POST: Promos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Prom,event_id,evCode,discount")] Promos promos)
        {
            ModelState.Remove("Events"); // Remover a validação da propriedade Events

            if (ModelState.IsValid)
            {
                var selectedEvent = await _context.Events.FirstOrDefaultAsync(e => e.event_id == promos.event_id);

                if (selectedEvent != null)
                {
                    if (selectedEvent.startDate <= DateTime.Today && selectedEvent.endDate >= DateTime.Today)
                    {
                        promos.promState = true;
                    }
                    else
                    {
                        promos.promState = false;
                    }
                }
                else
                {
                    ModelState.AddModelError("event_id", "Evento não encontrado.");
                }

                _context.Add(promos);
                await _context.SaveChangesAsync();

                ViewBag.Entity = "Promo";
                ViewBag.Controller = "Promos";
                ViewBag.Action = "Details";
                ViewBag.Id = promos.Id_Prom;

                return View("CreateSuccess");
            }
            else
            {
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage); // Log dos erros
                    }
                }
                ModelState.AddModelError(string.Empty, "Erro ao validar a promo. Verifique os campos obrigatórios.");
            }

            var events = _context.Events
                .Where(e => e.inUse)
                .Select(e => new { e.event_id, e.nameEv })
                .ToList();
            ViewBag.Events = new SelectList(events, "event_id", "nameEv");

            return View(promos);
        }



        // GET: Promos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promos = await _context.Promos.FindAsync(id);
            if (promos == null)
            {
                return NotFound();
            }
            return View(promos);
        }

        // POST: Promos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Prom,event_id,evCode,discount,promState")] Promos promos)
        {
            if (id != promos.Id_Prom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromosExists(promos.Id_Prom))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Entity = "Promo";
                ViewBag.Controller = "Promos";
                ViewBag.Action = "Details";
                ViewBag.Id = promos.Id_Prom;

                return View("CreateSuccess");
            }
            return View(promos);
        }

        // GET: Promos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promos = await _context.Promos
                .FirstOrDefaultAsync(m => m.Id_Prom == id);
            if (promos == null)
            {
                return NotFound();
            }

            return View(promos);
        }

        // POST: Promos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promos = await _context.Promos.FindAsync(id);
            if (promos != null)
            {
                _context.Promos.Remove(promos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromosExists(int id)
        {
            return _context.Promos.Any(e => e.Id_Prom == id);
        }
    }
}
