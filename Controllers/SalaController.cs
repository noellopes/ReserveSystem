using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveSystem.Controllers
{
    public class SalaController : Controller
    {
        private readonly ReserveSystemContext _context;

        public SalaController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Sala
        public IActionResult Index()
        {
            if (_context.Sala.Any())
            {
                _context.Sala.RemoveRange(_context.Sala);
                _context.SaveChanges();
            }

            if (!_context.Sala.Any())
            {
                if (!_context.TipoSala.Any())
                {
                    var predefinedTipoSala = new List<TipoSala>
                    {
                        new TipoSala { NomeSala = "Sala de Conferência", TamanhoSala = 50, Capacidade = 30, PreçoHora = 100.00 },
                        new TipoSala { NomeSala = "Auditório", TamanhoSala = 200, Capacidade = 150, PreçoHora = 300.00 },
                        new TipoSala { NomeSala = "Sala de Reuniões Pequena", TamanhoSala = 20, Capacidade = 10, PreçoHora = 50.00 }
                    };

                    _context.TipoSala.AddRange(predefinedTipoSala);
                    _context.SaveChanges();
                }

                var tipoSalas = _context.TipoSala.ToList();

                var predefinedSala = new List<Sala>
                {
                    new Sala { HoraInicio = DateTime.Today.AddHours(8), HoraFim = DateTime.Today.AddHours(12), IdTipoSala = tipoSalas[0].IdTipoSala },
                    new Sala { HoraInicio = DateTime.Today.AddHours(13), HoraFim = DateTime.Today.AddHours(17), IdTipoSala = tipoSalas[1].IdTipoSala },
                    new Sala { HoraInicio = DateTime.Today.AddHours(9), HoraFim = DateTime.Today.AddHours(11), IdTipoSala = tipoSalas[2].IdTipoSala }
                };

                _context.Sala.AddRange(predefinedSala);
                _context.SaveChanges();
            }

            var salas = _context.Sala.Include(s => s.TipoSala).ToList();
            if (!salas.Any())
            {
                ViewBag.EmptyMessage = "No Sala available in the system.";
                return View(Enumerable.Empty<Sala>());
            }
            return View(salas);

        }

        // GET: Sala/Details/{id}
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Sala = await _context.Sala
                .Include(r => r.TipoSala)
                .FirstOrDefaultAsync(r => r.IdSala == id);

            if (Sala == null)
            {
                ViewBag.ErrorMessage = $"Sala with ID {id} not found.";
                return View("Error");
            }

            return View(Sala);
        }

        // GET: Sala/Create
        public IActionResult Create()
        {
            ViewData["IdTipoSala"] = new SelectList(_context.TipoSala, "IdTipoSala", "NomeSala");
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sala Sala)
        {
            if (!ModelState.IsValid)
            {
                ViewData["IdTipoSala"] = new SelectList(_context.TipoSala, "IdTipoSala", "NomeSala", Sala.IdTipoSala);
                return View(Sala);
            }

            _context.Add(Sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Sala/Edit/{id}
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Sala = await _context.Sala.FindAsync(id);
            if (Sala == null)
            {
                ViewBag.ErrorMessage = $"Sala with ID {id} not found.";
                return View("Error");
            }

            ViewData["IdTipoSala"] = new SelectList(_context.TipoSala, "IdTipoSala", "NomeSala", Sala.IdTipoSala);
            return View(Sala);
        }

        // POST: Sala/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Sala Sala)
        {
            if (id != Sala.IdSala)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewData["IdTipoSala"] = new SelectList(_context.TipoSala, "IdTipoSala", "NomeSala", Sala.IdTipoSala);
                return View(Sala);
            }

            try
            {
                _context.Update(Sala);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(Sala.IdSala))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Sala/Delete/{id}
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Sala = await _context.Sala
                .Include(r => r.TipoSala)
                .FirstOrDefaultAsync(r => r.IdSala == id);

            if (Sala == null)
            {
                ViewBag.ErrorMessage = $"Sala with ID {id} not found.";
                return View("Error");
            }

            return View(Sala);
        }

        // POST: Sala/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var Sala = await _context.Sala.FindAsync(id);
            if (Sala == null)
            {
                ViewBag.ErrorMessage = $"Sala with ID {id} not found.";
                return View("Error");
            }

            _context.Sala.Remove(Sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(long id)
        {
            return _context.Sala.Any(r => r.IdSala == id);
        }
    }
}
