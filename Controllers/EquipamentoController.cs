using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Linq;

namespace ReserveSystem.Controllers
{
    public class EquipamentoController : Controller
    {
        private readonly ReserveSystemContext _context;
        private readonly ILogger<EquipamentoController> _logger;

        public EquipamentoController(ReserveSystemContext context, ILogger<EquipamentoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string filterNomeEquipamento, long? filterTipoEquipamento, int page = 1)
        {
            var equipamentos = _context.Equipamento.AsQueryable();

            if (!string.IsNullOrEmpty(filterNomeEquipamento))
            {
                equipamentos = equipamentos.Where(e => e.NomeEquipamento.Contains(filterNomeEquipamento));
            }

            if (filterTipoEquipamento.HasValue)
            {
                equipamentos = equipamentos.Where(e => e.IdTipoEquipamento == filterTipoEquipamento.Value);
            }

            var totalItems = await equipamentos.CountAsync();
            var equipamentosList = await equipamentos
                .OrderBy(e => e.NomeEquipamento)
                .Skip((page - 1) * 6)
                .Take(6)
                .ToListAsync();

            var viewModel = new EquipamentoViewModel
            {
                Equipamentos = equipamentosList,
                FilterNomeEquipamento = filterNomeEquipamento,
                FilterTipoEquipamento = filterTipoEquipamento?.ToString(), // Fix for CS0029
                TipoEquipamento = _context.TipoEquipamento.ToList(),
                Paginacao = new Paginacao
                {
                    PaginaCorrente = page,
                    ItemTotal = totalItems,
                },
            };

            return View(viewModel);
        }

        public IActionResult AddEquipment()
        {
            PopulateTipoEquipamento();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEquipment(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Equipamento.Add(equipamento);
                    _context.SaveChanges();
                    TempData["Message"] = $"The equipment '{equipamento.NomeEquipamento}' has been successfully added.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error adding equipment");
                    TempData["Message"] = "An unexpected error occurred while adding the equipment.";
                }
            }
            PopulateTipoEquipamento();
            return View(equipamento);
        }

        public IActionResult Edit(long id)
        {
            var equipamento = _context.Equipamento.Find(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            PopulateTipoEquipamento();
            return View(equipamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamento);
                    _context.SaveChanges();
                    TempData["Message"] = $"The equipment '{equipamento.NomeEquipamento}' has been edited.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error editing equipment");
                    TempData["Message"] = "An unexpected error occurred while editing the equipment.";
                }
            }
            PopulateTipoEquipamento();
            return View(equipamento);
        }


        public IActionResult Delete(long id)
        {
            var equipamento = _context.Equipamento.Include(e => e.TipoEquipamento).FirstOrDefault(e => e.IdEquipamento == id);
            if (equipamento == null)
            {
                return NotFound();
            }
            var tipoEquipamentoDict = _context.TipoEquipamento.ToDictionary(te => te.IdTipoEquipamento, te => te.NomeTipoEquipamento);
            ViewBag.TipoEquipamentoDict = tipoEquipamentoDict;
            return View(equipamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var equipamento = _context.Equipamento.Find(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            _context.Equipamento.Remove(equipamento);
            _context.SaveChanges();

            TempData["Message"] = $"The equipment '{equipamento.NomeEquipamento}' has been successfully deleted.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CheckEquipments()
        {
            var equipamentos = _context.Equipamento.ToList();
            return Json(equipamentos);
        }

        private void PopulateTipoEquipamento()
        {
            var tipoEquipamentoList = _context.TipoEquipamento
                .Select(te => new SelectListItem
                {
                    Value = te.IdTipoEquipamento.ToString(),
                    Text = te.NomeTipoEquipamento
                }).ToList();

            tipoEquipamentoList.Insert(0, new SelectListItem { Value = "", Text = "-- Choose Equipment Type -- " });

            ViewData["TipoEquipamento"] = tipoEquipamentoList;
        }
    }
}
