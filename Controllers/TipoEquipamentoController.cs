using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TipoEquipamentoController : Controller
    {

        private readonly ILogger<TipoEquipamentoController> _logger;
        private readonly ReserveSystemContext _context;

        public TipoEquipamentoController(ReserveSystemContext context, ILogger<TipoEquipamentoController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: TipoEquipamentoController
        public IActionResult Index()
        {
            var equipamentos = _context.TipoEquipamento.Include(e => e.Equipamento).ToList();
            return View(equipamentos);
        }

        // GET: TipoEquipamentoController/Details/5
        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var tipoEquipamento = _context.TipoEquipamento.Find(id);
                if (tipoEquipamento == null)
                {
                    return NotFound();
                }
                return View(tipoEquipamento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching equipment type details");
                TempData["Message"] = "An unexpected error occurred while fetching the equipment type details.";
                return View();
            }

        }

        // GET: TipoEquipamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEquipamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoEquipamento tipoEquipamento)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(tipoEquipamento);
            }
            try
            {
                _context.Add(tipoEquipamento);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating TipoEquipamento");
                TempData["Message"] = "An unexpected error occurred while creating the TipoEquipamento.";
                return View(tipoEquipamento);
            }
        }

        // GET: TipoEquipamentoController/Edit/5
        public async Task<ActionResult> EditAsync(long id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TipoEquipamento.FindAsync(id);
            if (tipoSala == null) return NotFound();

            return View("Edit", tipoSala);
        }

        // POST: TipoEquipamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(long id, IFormCollection collection)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var tipoEquipamento = _context.TipoEquipamento.Find(id);
                if (await TryUpdateModelAsync(tipoEquipamento, "", s => s.NomeTipoEquipamento))
                {
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(tipoEquipamento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating TipoEquipamento");
                TempData["Message"] = "An unexpected error occurred while updating the TipoEquipamento.";
                return View();
            }
        }

        // GET: TipoEquipamentoController/Delete/5
        public async Task<ActionResult> DeleteAsync(long id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TipoEquipamento.FirstOrDefaultAsync(m => m.IdTipoEquipamento == id);
            if (tipoSala == null) return NotFound();

            return View("Delete", tipoSala);
        }

        // POST: TipoEquipamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(long id, IFormCollection collection)
        {
            try
            {
                var tipoEquipamento = await _context.TipoEquipamento.FindAsync(id);
                if (tipoEquipamento == null)
                {
                    TempData["Message"] = "Equipment Type not found.";
                    return NotFound();
                }

                _context.TipoEquipamento.Remove(tipoEquipamento);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Equipment Type deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Database update error while deleting equipment type");
                TempData["Message"] = "A database error occurred while deleting the equipment type.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting equipment type");
                TempData["Message"] = "An unexpected error occurred while deleting the equipment type.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
