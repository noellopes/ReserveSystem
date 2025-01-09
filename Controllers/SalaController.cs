using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Client,Manager,Reservationist")]
        public async Task<IActionResult> Index(string roomType = null, TimeOnly? startTime = null,
            TimeOnly? endTime = null, int? floor = null, int page = 1)
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


        // GET: Sala/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            PopulateTipoSalaDropdown();
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sala sala)
        {
            if (!ModelState.IsValid)
            {
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }

            // Attach related TipoSala for display purposes
            sala.TipoSala = _context.TipoSala.FirstOrDefault(t => t.IdTipoSala == sala.IdTipoSala);

            if (sala.TipoSala == null)
            {
                TempData["ErrorMessage"] = "Invalid Room Type selected.";
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }

            return View("ConfirmCreate", sala);
        }

        // POST: Sala/FinalizeCreate
        [HttpPost]
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinalizeCreate(Sala sala)
        {
            try
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Room {sala.RoomNumber} on Floor {sala.Floor} created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Sala.");
                TempData["ErrorMessage"] = "An unexpected error occurred while creating the Sala.";
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View("Create", sala);
            }
        }

        // GET: Sala/Edit/{id}
        [Authorize(Roles = "Manager,Reservationist")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Invalid Room ID.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var sala = await _context.Sala.Include(s => s.TipoSala).FirstOrDefaultAsync(m => m.IdSala == id);
                if (sala == null)
                {
                    TempData["ErrorMessage"] = "Room not found.";
                    return RedirectToAction(nameof(Index));
                }

                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Room details for editing.");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching Room details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Sala/Edit
        [HttpPost]
        [Authorize(Roles = "Manager,Reservationist")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sala sala)
        {
            if (!ModelState.IsValid)
            {
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }

            sala.TipoSala = _context.TipoSala.FirstOrDefault(t => t.IdTipoSala == sala.IdTipoSala);

            if (sala.TipoSala == null)
            {
                TempData["ErrorMessage"] = "Invalid Room Type selected.";
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View(sala);
            }

            return View("ConfirmEdit", sala);
        }

        // POST: Sala/FinalizeEdit
        [HttpPost]
        [Authorize(Roles = "Manager,Reservationist")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinalizeEdit(Sala sala)
        {
            try
            {
                _context.Update(sala);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Room {sala.RoomNumber} on Floor {sala.Floor} updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Sala.");
                TempData["ErrorMessage"] = "An unexpected error occurred while updating the Sala.";
                PopulateTipoSalaDropdown(sala.IdTipoSala);
                return View("Edit", sala);
            }
        }

        // GET: Sala/Delete/{id}
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
                TempData["Message"] = $"Room {sala.RoomNumber} on Floor {sala.Floor} deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Sala.");
                TempData["ErrorMessage"] = "An unexpected error occurred while deleting the Sala.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Sala/Details/{id}
        [Authorize(Roles = "Client,Manager,Reservationist")]
        public async Task<IActionResult> Details(long? id)
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

                return View("Details", sala);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Sala details.");
                TempData["ErrorMessage"] = "An unexpected error occurred while fetching Sala details.";
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
    }
}