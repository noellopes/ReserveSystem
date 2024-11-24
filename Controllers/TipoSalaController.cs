using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TipoSalaController : Controller
    {
        private readonly ReserveSystemContext _context;

        private readonly ILogger<TipoSalaController> _logger;

        public TipoSalaController(ReserveSystemContext context, ILogger<TipoSalaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: TipoSala
        public async Task<IActionResult> Index()
        {
            try
            {
                var tipoSalas = await _context.TipoSala.ToListAsync();
                return View(tipoSalas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching TipoSala list");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching the TipoSala list.";
                return View(new List<TipoSala>()); // Boş bir list döndür geçici olarak
            }
        }


        // GET: TipoSala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdTipoSala,NomeSala,TamanhoSala,Capacidade,PreçoHora")] TipoSala tipoSala)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(tipoSala);
            }

            try
            {
                _context.Add(tipoSala);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "TipoSala created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating TipoSala");
                TempData["ErrorMessage"] = "An unexpected error occurred while creating the TipoSala.";
                return View(tipoSala);
            }
        }

        // GET: TipoSala/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Invalid TipoSala ID.";
                return NotFound();
            }

            try
            {
                var tipoSala = await _context.TipoSala.FirstOrDefaultAsync(m => m.IdTipoSala == id);
                if (tipoSala == null)
                {
                    TempData["ErrorMessage"] = "TipoSala not found.";
                    return NotFound();
                }

                return View(tipoSala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching TipoSala details");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching the TipoSala details.";
                return RedirectToAction(nameof(Index));
            }
        }


        // GET: TipoSala/Edit/{id}
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TipoSala.FindAsync(id);
            if (tipoSala == null) return NotFound();

            return View("Edit", tipoSala);
        }

        // POST: TipoSala/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("IdTipoSala,NomeSala,TamanhoSala,Capacidade,PreçoHora")] TipoSala tipoSala)
        {
            if (id != tipoSala.IdTipoSala)
            {
                TempData["ErrorMessage"] = "Invalid TipoSala ID.";
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(tipoSala);
            }

            try
            {
                _context.Update(tipoSala);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "TipoSala updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TipoSalaExists(tipoSala.IdTipoSala))
                {
                    TempData["ErrorMessage"] = "TipoSala not found.";
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, "Concurrency error while updating TipoSala");
                    TempData["ErrorMessage"] = "A concurrency error occurred while updating the TipoSala.";
                    return View(tipoSala);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating TipoSala");
                TempData["ErrorMessage"] = "An unexpected error occurred while updating the TipoSala.";
                return View(tipoSala);
            }
        }

        private bool TipoSalaExists(long id)
        {
            return _context.TipoSala.Any(e => e.IdTipoSala == id);
        }


        // GET: TipoSala/Delete/{id}
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TipoSala.FirstOrDefaultAsync(m => m.IdTipoSala == id);
            if (tipoSala == null) return NotFound();

            return View("Delete", tipoSala);
        }

        // POST: TipoSala/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long IdTipoSala)
        {
            try
            {
                var tipoSala = await _context.TipoSala.FindAsync(IdTipoSala);
                if (tipoSala == null)
                {
                    TempData["ErrorMessage"] = "TipoSala not found.";
                    return NotFound();
                }

                _context.TipoSala.Remove(tipoSala);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "TipoSala deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting TipoSala");
                TempData["ErrorMessage"] = "An unexpected error occurred while deleting the TipoSala.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}