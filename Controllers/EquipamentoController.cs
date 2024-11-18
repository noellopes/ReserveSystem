using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Linq;

namespace ReserveSystem.Controllers
{
    public class EquipamentoController : Controller
    {
        private readonly ReserveSystemContext _context;

        public EquipamentoController(ReserveSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!_context.Equipamento.Any())
            {
                var listaEquipamentos = new List<Equipamento>
                {
                    new Equipamento { NomeEquipamento = "Projetor", TipoEquipamento = "Eletrônico", Quantidade = 3 },
                    new Equipamento { NomeEquipamento = "Sistema de Som", TipoEquipamento = "Eletrônico", Quantidade = 2 },
                    new Equipamento { NomeEquipamento = "Microfone", TipoEquipamento = "Eletrônico", Quantidade = 5 },
                    new Equipamento { NomeEquipamento = "Quadro Branco", TipoEquipamento = "Mobiliário", Quantidade = 3 },
                    new Equipamento { NomeEquipamento = "Mesa de Conferência", TipoEquipamento = "Mobiliário", Quantidade = 1 }
                };

                _context.Equipamento.AddRange(listaEquipamentos);
                _context.SaveChanges();
            }

            var equipamentos = _context.Equipamento.ToList();
            return View(equipamentos);
        }

        public IActionResult Edit(int id)
        {
            var equipamento = _context.Equipamento.Find(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            return View(equipamento);
        }

        [HttpPost]
        public IActionResult Edit(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Update(equipamento);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(equipamento);
        }


        public IActionResult Delete(int id)
        {
            var equipamento = _context.Equipamento.Find(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            return View(equipamento);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var equipamento = _context.Equipamento.Find(id);
            _context.Equipamento.Remove(equipamento);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ReportIssue(int id)
        {
            var equipamento = _context.Equipamento.Find(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            return View(equipamento);
        }

        [HttpPost]
        public IActionResult ReportIssue(int id, string issueDescription)
        { 
            // Logic to handle reporting the issue 
          // You can store the issue report in a database table or send a notification, etc.
            return RedirectToAction(nameof(Index));
        }
    }
}
