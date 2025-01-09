using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Client,Manager,Reservationist")]
        public async Task<IActionResult> Index(int? minCapacity = null, int? maxCapacity = null, int page = 1)
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
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSala/Create -> Confirm
        [HttpPost]
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmCreate(TipoSala tipoSala)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", tipoSala);
            }

            return View("ConfirmCreate", tipoSala);
        }

        // POST: TipoSala/Create -> Finalize
        [HttpPost]
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinalizeCreate(TipoSala tipoSala)
        {
            try
            {
                _context.Add(tipoSala);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Room Type '{tipoSala.NomeSala}' created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating TipoSala");
                TempData["ErrorMessage"] = "An unexpected error occurred while creating the Room Type.";
                return View("Create", tipoSala);
            }
        }

        // GET: TipoSala/Edit/{id}
        [Authorize(Roles = "Manager,Reservationist")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Invalid Room Type ID.";
                return RedirectToAction(nameof(Index));
            }

            var tipoSala = await _context.TipoSala.FindAsync(id);
            if (tipoSala == null)
            {
                TempData["ErrorMessage"] = "Room Type not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(tipoSala);
        }

        // POST: TipoSala/Edit -> Confirm
        [HttpPost]
        [Authorize(Roles = "Manager,Reservationist")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmEdit(TipoSala tipoSala)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", tipoSala);
            }

            return View("ConfirmEdit", tipoSala);
        }

        // POST: TipoSala/Edit -> Finalize
        [HttpPost]
        [Authorize(Roles = "Manager,Reservationist")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinalizeEdit(TipoSala tipoSala)
        {
            try
            {
                _context.Update(tipoSala);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Room Type '{tipoSala.NomeSala}' updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TipoSalaExists(tipoSala.IdTipoSala))
                {
                    TempData["ErrorMessage"] = "Room Type not found.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError(ex, "Concurrency error while updating TipoSala");
                    TempData["ErrorMessage"] = "A concurrency error occurred while updating the Room Type.";
                    return View("Edit", tipoSala);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Room Type");
                TempData["ErrorMessage"] = "An unexpected error occurred while updating the Room Type.";
                return View("Edit", tipoSala);
            }
        }

        // GET: TipoSala/Delete/{id}
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Invalid Room Type ID.";
                return RedirectToAction(nameof(Index));
            }

            var tipoSala = await _context.TipoSala.FirstOrDefaultAsync(m => m.IdTipoSala == id);
            if (tipoSala == null)
            {
                TempData["ErrorMessage"] = "Room Type not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(tipoSala);
        }


        // POST: TipoSala/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                var tipoSala = await _context.TipoSala.FindAsync(id);
                if (tipoSala == null)
                {
                    TempData["ErrorMessage"] = "Room Type not found.";
                    return RedirectToAction(nameof(Index));
                }

                _context.TipoSala.Remove(tipoSala);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Room Type '{tipoSala.NomeSala}' deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting TipoSala");
                TempData["ErrorMessage"] = "An unexpected error occurred while deleting the Room Type.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: TipoSala/Details/{id}
        [Authorize(Roles = "Client,Manager,Reservationist")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Invalid Room Type ID.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var tipoSala = await _context.TipoSala.FirstOrDefaultAsync(m => m.IdTipoSala == id);

                if (tipoSala == null)
                {
                    TempData["ErrorMessage"] = "Room Type not found.";
                    return RedirectToAction(nameof(Index));
                }

                return View(tipoSala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Room Type details.");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching Room Type details.";
                return RedirectToAction(nameof(Index));
            }
        }


        private bool TipoSalaExists(long id)
        {
            return _context.TipoSala.Any(e => e.IdTipoSala == id);
        }
    }
}