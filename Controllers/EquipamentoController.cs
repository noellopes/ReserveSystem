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
            if (_context.Equipamento.Any())
            {
                _context.Equipamento.RemoveRange(_context.Equipamento);
                _context.SaveChanges();
            }

            if (!_context.Equipamento.Any())
            {

                var listaEquipamentos = new List<Equipamento>
                {
                    new Equipamento { NomeEquipamento = "Projector", TipoEquipamento = "Electronic", Quantidade = 3 },
                    new Equipamento { NomeEquipamento = "Sound System", TipoEquipamento = "Electronic", Quantidade = 8 },
                    new Equipamento { NomeEquipamento = "Microphone", TipoEquipamento = "Electronic", Quantidade = 30 },
                    new Equipamento { NomeEquipamento = "Whiteboard", TipoEquipamento = "Furniture", Quantidade = 7 },
                    new Equipamento { NomeEquipamento = "Conference Table", TipoEquipamento = "Furniture", Quantidade = 10 },
                    new Equipamento { NomeEquipamento = "Chairs", TipoEquipamento = "Furniture", Quantidade = 500 },
                    new Equipamento { NomeEquipamento = "Podium", TipoEquipamento = "Furniture", Quantidade = 5 },
                    new Equipamento { NomeEquipamento = "Video Conferencing System", TipoEquipamento = "Electronic", Quantidade = 2 },
                    new Equipamento { NomeEquipamento = "Stage Lighting", TipoEquipamento = "Lighting", Quantidade = 10 },
                    new Equipamento { NomeEquipamento = "Sound Mixer", TipoEquipamento = "Electronic", Quantidade = 1 },
                    new Equipamento { NomeEquipamento = "Projection Screen", TipoEquipamento = "Furniture", Quantidade = 5 },
                    new Equipamento { NomeEquipamento = "Flipcharts", TipoEquipamento = "Furniture", Quantidade = 4 },
                    new Equipamento { NomeEquipamento = "Wi-Fi Router", TipoEquipamento = "Electronic", Quantidade = 5 },
                    new Equipamento { NomeEquipamento = "Laptop", TipoEquipamento = "Electronic", Quantidade = 10 },
                    new Equipamento { NomeEquipamento = "Power Strips", TipoEquipamento = "Accessories", Quantidade = 10 },
                    new Equipamento { NomeEquipamento = "HDMI Cables", TipoEquipamento = "Accessories", Quantidade = 13 },
                    new Equipamento { NomeEquipamento = "Portable Speaker", TipoEquipamento = "Electronic", Quantidade = 3 },
                    new Equipamento { NomeEquipamento = "Laser Pointer", TipoEquipamento = "Accessories", Quantidade = 5 },
                    new Equipamento { NomeEquipamento = "Coffee Maker", TipoEquipamento = "Kitchen Equipment", Quantidade = 11 },
                    new Equipamento { NomeEquipamento = "Thermos", TipoEquipamento = "Kitchen Equipment", Quantidade = 5 }
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

        public IActionResult CheckEquipments()
        {
            var equipamentos = _context.Equipamento.ToList();
            return Json(equipamentos);
        }

    }
}
