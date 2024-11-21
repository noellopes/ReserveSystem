using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Linq;

namespace ReserveSystem.Controllers
{
    public class TipoSalaController : Controller
    {
        private readonly ReserveSystemContext _context;

        public TipoSalaController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: TipoSala
        public IActionResult Index()
        {
            // Add predefined TipoSala instances if none exist
            if (!_context.TipoSala.Any())
            {
                var predefinedTipoSala = new List<TipoSala>
                {
                    new TipoSala { NomeSala = "Conference Room", TamanhoSala = 50, Capacidade = 30, PreçoHora = 100.00 },
                    new TipoSala { NomeSala = "Auditorium", TamanhoSala = 200, Capacidade = 150, PreçoHora = 300.00 },
                    new TipoSala { NomeSala = "Small Meeting Room", TamanhoSala = 20, Capacidade = 10, PreçoHora = 50.00 },
                    new TipoSala { NomeSala = "Training Room", TamanhoSala = 100, Capacidade = 50, PreçoHora = 150.00 },
                    new TipoSala { NomeSala = "Boardroom", TamanhoSala = 40, Capacidade = 20, PreçoHora = 120.00 },
                    new TipoSala { NomeSala = "Breakout Room", TamanhoSala = 30, Capacidade = 15, PreçoHora = 75.00 },
                    new TipoSala { NomeSala = "Workshop Room", TamanhoSala = 80, Capacidade = 40, PreçoHora = 200.00 },
                    new TipoSala { NomeSala = "Interview Room", TamanhoSala = 15, Capacidade = 5, PreçoHora = 30.00 }
                };

                _context.TipoSala.AddRange(predefinedTipoSala);
                _context.SaveChanges();
            }

            // Retrieve all TipoSala records to display
            var tipoSalas = _context.TipoSala.ToList();
            if (!tipoSalas.Any())
            {
                ViewBag.EmptyMessage = "No TipoSala available in the system.";
            }
            return View(tipoSalas);
        }


        // GET: TipoSala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoSala tipoSala)
        {
            if (ModelState.IsValid)
            {
                _context.TipoSala.Add(tipoSala);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSala);
        }

        // GET: TipoSala/Edit/{id}
        public IActionResult Edit(long id)
        {
            var tipoSala = _context.TipoSala.Find(id);
            if (tipoSala == null)
            {
                return NotFound();
            }
            return View(tipoSala);
        }

        // POST: TipoSala/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TipoSala tipoSala)
        {
            if (ModelState.IsValid)
            {
                _context.TipoSala.Update(tipoSala);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSala);
        }

        // GET: TipoSala/Delete/{id}
        public IActionResult Delete(long id)
        {
            var tipoSala = _context.TipoSala.Find(id);
            if (tipoSala == null)
            {
                return NotFound();
            }
            return View(tipoSala);
        }

        // POST: TipoSala/Delete/{id}
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var tipoSala = _context.TipoSala.Find(id);
            if (tipoSala != null)
            {
                _context.TipoSala.Remove(tipoSala);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoSala/Details/{id}
        public IActionResult Details(long id)
        {
            var tipoSala = _context.TipoSala.Find(id);
            if (tipoSala == null)
            {
                return NotFound();
            }
            return View(tipoSala);
        }
    }
}
