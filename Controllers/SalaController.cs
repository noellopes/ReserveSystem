using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class SalaController : Controller
    {
        private readonly ReserveSystemContext _context;

        public SalaController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Sala
        public async Task<IActionResult> Index()
        {
            var salas = await _context.Salas
                .Include(s => s.TipoSala)
                .ToListAsync();

            // Handle the case where no Salas exist
            if (salas == null || !salas.Any())
            {
                ViewBag.EmptyMessage = "No Salas available in the system.";
                return View(Enumerable.Empty<Sala>());
            }

            return View(salas);
        }

        // GET: Sala/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .Include(s => s.TipoSala)
                .FirstOrDefaultAsync(m => m.IdSala == id);

            if (sala == null)
            {
                ViewBag.ErrorMessage = $"Sala with ID {id} not found.";
                return View("Error");
            }

            return View(sala);
        }

        // GET: Sala/Create
        public IActionResult Create()
        {
            if (!_context.TipoSalas.Any())
            {
                ViewBag.ErrorMessage = "No TipoSalas available. Create a TipoSala first.";
                return View("Error");
            }

            ViewData["IdTipoSala"] = new SelectList(_context.TipoSalas, "IdTipoSala", "NomeAvaria");
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sala sala)
        {
            if (!ModelState.IsValid)
            {
                ViewData["IdTipoSala"] = new SelectList(_context.TipoSalas, "IdTipoSala", "NomeAvaria", sala.IdTipoSala);
                return View(sala);
            }

            _context.Add(sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Sala/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                ViewBag.ErrorMessage = $"Sala with ID {id} not found.";
                return View("Error");
            }

            if (!_context.TipoSalas.Any())
            {
                ViewBag.ErrorMessage = "No TipoSalas available. Create a TipoSala first.";
                return View("Error");
            }

            ViewData["IdTipoSala"] = new SelectList(_context.TipoSalas, "IdTipoSala", "NomeAvaria", sala.IdTipoSala);
            return View(sala);
        }

        // POST: Sala/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Sala sala)
        {
            if (id != sala.IdSala)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewData["IdTipoSala"] = new SelectList(_context.TipoSalas, "IdTipoSala", "NomeAvaria", sala.IdTipoSala);
                return View(sala);
            }

            try
            {
                _context.Update(sala);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(sala.IdSala))
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

        // GET: Sala/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .Include(s => s.TipoSala)
                .FirstOrDefaultAsync(m => m.IdSala == id);

            if (sala == null)
            {
                ViewBag.ErrorMessage = $"Sala with ID {id} not found.";
                return View("Error");
            }

            return View(sala);
        }

        // POST: Sala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                ViewBag.ErrorMessage = $"Sala with ID {id} not found.";
                return View("Error");
            }

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(long id)
        {
            return _context.Salas.Any(e => e.IdSala == id);
        }
    }
}
