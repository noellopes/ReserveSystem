using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Data;
using ReserveSystem.Models;
using ReserveSystem.Models.ViewModels;

namespace ReserveSystem.Controllers
{
    public class SalaController : Controller
    {
        private readonly ReserveSystemContext _context;
        private readonly ILogger<SalaController> _logger;

        public SalaController(ReserveSystemContext context, ILogger<SalaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Sala
        public async Task<IActionResult> Index()
        {
            try
            {
                var query = ApplySalaFilters(_context.Sala.Include(s => s.TipoSala).AsQueryable(), roomType, startTime,
                    endTime, floor);

                int totalItems = await query.CountAsync();

                var salas = await query
                    .OrderBy(s => s.RoomNumber)
                    .Skip((page - 1) * 10)
                    .Take(10)
                    .ToListAsync();

                PopulateViewBags(roomType, floor);

                var viewModel = new SalaViewModel
                {
                    Salas = salas,
                    Pagination = new PagingInfo
                    {
                        TotalItems = totalItems,
                        CurrentPage = page,
                        PageSize = 10
                    },
                    RoomTypeFilter = roomType,
                    StartTimeFilter = startTime,
                    EndTimeFilter = endTime,
                    FloorFilter = floor
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Sala list");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching the Sala list.";
                return View(new SalaViewModel());
            }
        }

        private IQueryable<Sala> ApplySalaFilters(IQueryable<Sala> query, string? roomType, TimeOnly? startTime,
            TimeOnly? endTime, int? floor)
        {
            if (!string.IsNullOrEmpty(roomType))
                query = query.Where(s => s.TipoSala != null && s.TipoSala.NomeSala == roomType);

            if (floor.HasValue)
                query = query.Where(s => s.Floor == floor.Value);

            if (startTime.HasValue && endTime.HasValue)
                query = query.Where(s => s.HoraInicio <= startTime.Value && s.HoraFim >= endTime.Value);

            return query;
        }

        private void PopulateViewBags(string? roomType, int? floor)
        {
            ViewBag.TipoSalaList = new SelectList(
                _context.TipoSala.Select(t => new { t.NomeSala }).Distinct(),
                "NomeSala",
                "NomeSala",
                roomType
            );

            ViewBag.FloorList = new SelectList(
                _context.Sala.Select(s => s.Floor).Distinct().OrderBy(f => f),
                floor
            );
        }

                return View("Details", sala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Sala details.");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching Sala details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Sala/Create
        public IActionResult Create()
        {
            PopulateTipoSalaDropdown();
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sala sala)
        {
            if (!ModelState.IsValid)
            {
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }

            try
            {
                if (!TimeSpan.TryParse(Request.Form["TempoPreparação"], out var parsedTempoPreparação))
                {
                    ModelState.AddModelError("TempoPreparação", "Invalid time format. Please use HH:mm.");
                    PopulateTipoSalaDropdown(sala.IdTipoSala);
                    return View(sala);
                }

                sala.TempoPreparação = parsedTempoPreparação;

                _context.Add(sala);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Room created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Sala.");
                TempData["ErrorMessage"] = "An unexpected error occurred while creating the Sala.";
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }
        }


        // GET: Sala/Edit/{id}
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Invalid Sala ID.";
                return NotFound();
            }

            try
            {
                var sala = await _context.Sala.FindAsync(id);
                if (sala == null)
                {
                    TempData["ErrorMessage"] = "Sala not found.";
                    return NotFound();
                }

                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Sala for editing.");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching Sala details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Sala/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Sala sala)
        {
            if (id != sala.IdSala)
            {
                TempData["ErrorMessage"] = "Invalid Sala ID.";
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }

            try
            {
                // Parse TempoPreparação from the form
                sala.TempoPreparação = TimeSpan.Parse(Request.Form["TempoPreparação"]);

                _context.Update(sala);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Room updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SalaExists(sala.IdSala))
                {
                    TempData["ErrorMessage"] = "Sala not found.";
                    return NotFound();
                }

                _logger.LogError(ex, "Concurrency error while updating Sala.");
                TempData["ErrorMessage"] = "A concurrency error occurred while updating the Sala.";
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Sala.");
                TempData["ErrorMessage"] = "An unexpected error occurred while updating the Sala.";
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }
        }


        // GET: Sala/Delete/{id}
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Invalid Sala ID.";
                return NotFound();
            }

            try
            {
                var sala = await _context.Sala.Include(s => s.TipoSala)
                    .FirstOrDefaultAsync(m => m.IdSala == id);

                if (sala == null)
                {
                    TempData["ErrorMessage"] = "Sala not found.";
                    return NotFound();
                }

                return View("Delete", sala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Sala for deletion.");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching Sala details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Sala/DeleteConfirmed/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                var sala = await _context.Sala.FindAsync(id);
                if (sala == null)
                {
                    TempData["ErrorMessage"] = "Sala not found.";
                    return NotFound();
                }

                _context.Sala.Remove(sala);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Room deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Sala.");
                TempData["ErrorMessage"] = "An unexpected error occurred while deleting the Sala.";
                return RedirectToAction(nameof(Index));
            }
        }

        private void PopulateTipoSalaDropdown(object selectedTipoSala = null)
        {
            ViewBag.TipoSalaList = new SelectList(
                _context.TipoSala,
                "IdTipoSala",
                "NomeSala",
                selectedTipoSala);
        }

        private bool SalaExists(long id)
        {
            return _context.Sala.Any(e => e.IdSala == id);
        }
    }
}