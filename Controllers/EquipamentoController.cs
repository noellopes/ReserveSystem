using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // Clean the Equipamento table if there are any entries 
            if (_context.Equipamento.Any(e => e.IdEquipamento >= 0)) 
            { 
                var equipamentosToDelete = _context.Equipamento.Where(e => e.IdEquipamento >= 30).ToList(); 
                _context.Equipamento.RemoveRange(equipamentosToDelete); 
                _context.SaveChanges();
            }

            if (!_context.Equipamento.Any())
            {       
                var listaEquipamentos = new List<Equipamento>
                {
                    new Equipamento { IdEquipamento = 1, NomeEquipamento = "Projector", TipoEquipamento = "Electronic", Quantidade = 3 }, 
                    new Equipamento { IdEquipamento = 2, NomeEquipamento = "Sound System", TipoEquipamento = "Electronic", Quantidade = 8 }, 
                    new Equipamento { IdEquipamento = 3, NomeEquipamento = "Microphone", TipoEquipamento = "Electronic", Quantidade = 30 }, 
                    new Equipamento { IdEquipamento = 4, NomeEquipamento = "Whiteboard", TipoEquipamento = "Furniture", Quantidade = 7 }, 
                    new Equipamento { IdEquipamento = 5, NomeEquipamento = "Conference Table", TipoEquipamento = "Furniture", Quantidade = 10 }, 
                    new Equipamento { IdEquipamento = 6, NomeEquipamento = "Chairs", TipoEquipamento = "Furniture", Quantidade = 500 }, 
                    new Equipamento { IdEquipamento = 7, NomeEquipamento = "Podium", TipoEquipamento = "Furniture", Quantidade = 5 }, 
                    new Equipamento { IdEquipamento = 8, NomeEquipamento = "Video Conferencing System", TipoEquipamento = "Electronic", Quantidade = 2 }, 
                    new Equipamento { IdEquipamento = 9, NomeEquipamento = "Stage Lighting", TipoEquipamento = "Lighting", Quantidade = 10 }, 
                    new Equipamento { IdEquipamento = 10, NomeEquipamento = "Sound Mixer", TipoEquipamento = "Electronic", Quantidade = 1 }, 
                    new Equipamento { IdEquipamento = 11, NomeEquipamento = "Projection Screen", TipoEquipamento = "Furniture", Quantidade = 5 }, 
                    new Equipamento { IdEquipamento = 12, NomeEquipamento = "Flipcharts", TipoEquipamento = "Furniture", Quantidade = 4 }, 
                    new Equipamento { IdEquipamento = 13, NomeEquipamento = "Wi-Fi Router", TipoEquipamento = "Electronic", Quantidade = 5 }, 
                    new Equipamento { IdEquipamento = 14, NomeEquipamento = "Laptop", TipoEquipamento = "Electronic", Quantidade = 10 }, 
                    new Equipamento { IdEquipamento = 15, NomeEquipamento = "Power Strips", TipoEquipamento = "Accessories", Quantidade = 10 }, 
                    new Equipamento { IdEquipamento = 16, NomeEquipamento = "HDMI Cables", TipoEquipamento = "Accessories", Quantidade = 13 }, 
                    new Equipamento { IdEquipamento = 17, NomeEquipamento = "Portable Speaker", TipoEquipamento = "Electronic", Quantidade = 3 }, 
                    new Equipamento { IdEquipamento = 18, NomeEquipamento = "Laser Pointer", TipoEquipamento = "Accessories", Quantidade = 5 }, 
                    new Equipamento { IdEquipamento = 19, NomeEquipamento = "Coffee Maker", TipoEquipamento = "Kitchen Equipment", Quantidade = 11 }, 
                    new Equipamento { IdEquipamento = 20, NomeEquipamento = "Thermos", TipoEquipamento = "Kitchen Equipment", Quantidade = 5 }
                };

                using (var transaction = _context.Database.BeginTransaction()) 
                {
                    try
                    { 
                        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Equipamento ON"); 
                        foreach (var equipamento in listaEquipamentos) 
                        { 
                            _context.Database.ExecuteSqlRaw(
                                "INSERT INTO Equipamento (IdEquipamento, NomeEquipamento, TipoEquipamento, Quantidade) VALUES ({0}, {1}, {2}, {3})", 
                                equipamento.IdEquipamento, equipamento.NomeEquipamento, equipamento.TipoEquipamento, equipamento.Quantidade);
                        }
                        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Equipamento OFF"); 
                        transaction.Commit(); 
                    } 
                    catch
                    { 
                        transaction.Rollback(); 
                        throw; 
                    } 
                }

            }

            var equipamentos = _context.Equipamento.ToList();
            return View(equipamentos);
        }

        public IActionResult AddEquipment() 
        { 
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEquipment(Equipamento equipamento) 
        {

            if (ModelState.IsValid)
            {
                _context.Add(equipamento);
                _context.SaveChanges();
                TempData["Message"] = "New equipment has been successfully added.";
                return RedirectToAction(nameof(Index));
            }
            return View(equipamento);
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
                TempData["Message"] = "The equipment has been edited.";
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

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var equipamento = _context.Equipamento.Find(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            _context.Equipamento.Remove(equipamento);
            _context.SaveChanges();

            TempData["Message"] = "The equipment has been successfully deleted.";
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
            TempData["Message"] = "The report has been sent to the technician.";
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
