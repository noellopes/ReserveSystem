using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using ReserveSystem.Models.ViewModels;

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
                var query = ApplyTipoSalaFilters(_context.TipoSala.AsQueryable(), minCapacity, maxCapacity);

                int totalItems = await query.CountAsync();

                var tipoSalas = await query
                    .OrderBy(t => t.NomeSala)
                    .Skip((page - 1) * 4)
                    .Take(4)
                    .ToListAsync();

                var viewModel = new TipoSalaViewModel
                {
                    TipoSalas = tipoSalas,
                    Pagination = new PagingInfo
                    {
                        TotalItems = totalItems,
                        CurrentPage = page,
                        PageSize = 4
                    },
                    MinCapacity = minCapacity,
                    MaxCapacity = maxCapacity
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching TipoSala list");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching the TipoSala list.";
                return View(new TipoSalaViewModel());
            }
        }

        private IQueryable<TipoSala> ApplyTipoSalaFilters(IQueryable<TipoSala> query, int? minCapacity,
            int? maxCapacity)
        {
            if (minCapacity.HasValue)
                query = query.Where(t => t.Capacidade >= minCapacity.Value);

            if (maxCapacity.HasValue)
                query = query.Where(t => t.Capacidade <= maxCapacity.Value);

            return query;
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
                TempData["Message"] = "Room Type created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating TipoSala");
                TempData["Message"] = "An unexpected error occurred while creating the TipoSala.";
                return View(tipoSala);
            }
        }

        // GET: TipoSala/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                TempData["Message"] = "Invalid TipoSala ID.";
                return NotFound();
            }

            try
            {
                var tipoSala = await _context.TipoSala.FirstOrDefaultAsync(m => m.IdTipoSala == id);
                if (tipoSala == null)
                {
                    TempData["Message"] = "TipoSala not found.";
                    return NotFound();
                }

                return View(tipoSala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching TipoSala details");
                TempData["Message"] = "An unexpected error occurred while fetching the TipoSala details.";
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
                TempData["Message"] = "Invalid Room Type ID.";
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
                TempData["Message"] = "Room Type updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TipoSalaExists(tipoSala.IdTipoSala))
                {
                    TempData["Message"] = "Room Type not found.";
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, "Concurrency error while updating TipoSala");
                    TempData["Message"] = "A concurrency error occurred while updating the TipoSala.";
                    return View(tipoSala);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Room Type");
                TempData["Message"] = "An unexpected error occurred while updating the Room Type";
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
                    TempData["Message"] = "Room Type not found.";
                    return NotFound();
                }

                _context.TipoSala.Remove(tipoSala);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Room Type deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting TipoSala");
                TempData["Message"] = "An unexpected error occurred while deleting the TipoSala.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}