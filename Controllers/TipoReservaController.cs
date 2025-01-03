using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TipoReservaController : Controller
    {
        private readonly ILogger<TipoReservaController> _logger;
        private readonly ReserveSystemContext _context;

        public TipoReservaController(ReserveSystemContext context, ILogger<TipoReservaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: TipoReserva
        public async Task<IActionResult> Index()
        {
            try
            {
                var tipoReservas = await _context.TipoReserva.ToListAsync();
                return View(tipoReservas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching TipoReserva list");
                TempData["Message"] = "An unexpected error occurred while fetching the TipoReserva list.";
                return View(new List<TipoReserva>()); // Temporary return an empty list
            }
        }

        // GET: TipoReserva/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var tipoReserva = await _context.TipoReserva
                    .FirstOrDefaultAsync(m => m.idTipoReserva == id);
                if (tipoReserva == null)
                {
                    return NotFound();
                }
                return View(tipoReserva);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching TipoReserva details");
                TempData["Message"] = "An unexpected error occurred while fetching the TipoReserva details.";
                return View();
            }
        }

        // GET: TipoReserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoReserva/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTipoReserva,NomeReserva")] TipoReserva tipoReserva)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tipoReserva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating the new booking type");
                    TempData["Message"] = "An unexpected error occurred while creating the booking type.";
                }
            }
            return View(tipoReserva);
        }

        // GET: TipoReserva/Edit/2
        public async Task<IActionResult> Edit(long id)
        {
            var tipoReserva = await _context.TipoReserva.FindAsync(id); // fetch the TipoReserva by id from the database
            if (tipoReserva == null)
            {
                return NotFound();
            }
            return View(tipoReserva);
        }

        // POST: TipoReserva/Edit/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("idTipoReserva,NomeReserva")] TipoReserva tipoReserva)
        {
            if (id != tipoReserva.idTipoReserva)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoReserva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoReservaExists(tipoReserva.idTipoReserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating the booking type");
                    TempData["Message"] = "An unexpected error occurred while updating the booking type.";
                }
            }
            return View(tipoReserva);
        }

        // GET: TipoReserva/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoReserva = await _context.TipoReserva
                .FirstOrDefaultAsync(m => m.idTipoReserva == id);
            if (tipoReserva == null)
            {
                return NotFound();
            }

            return View(tipoReserva);
        }

        // POST: TipoReserva/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                var tipoReserva = await _context.TipoReserva.FindAsync(id);
                if (tipoReserva != null)
                {
                    _context.TipoReserva.Remove(tipoReserva);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Booking type deleted successfully.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting the booking type");
                TempData["Message"] = "An unexpected error occurred while deleting the booking type.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }

        private bool TipoReservaExists(long id)
        {
            return _context.TipoReserva.Any(e => e.idTipoReserva == id);
        }
    }
}
