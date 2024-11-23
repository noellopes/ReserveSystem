using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class SalasController : Controller
    {
        private readonly ReserveSystemContext _context;

        public SalasController(ReserveSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var salas = _context.Sala.Include(s => s.TipoSala);
            return View(await salas.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();

            var sala = await _context.Sala.Include(s => s.TipoSala)
                            .FirstOrDefaultAsync(m => m.IdSala == id);

            if (sala == null) return NotFound();

            return View(sala);
        }

        public IActionResult Create()
        {
            ViewData["IdTipoSala"] = new SelectList(_context.TipoSala, "IdTipoSala", "NomeSala");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSala,TempoPreparação,HoraInicio,HoraFim,IdTipoSala")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdTipoSala"] = new SelectList(_context.TipoSala, "IdTipoSala", "NomeSala", sala.IdTipoSala);
            return View(sala);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null) return NotFound();

            var sala = await _context.Sala.FindAsync(id);

            if (sala == null) return NotFound();

            ViewData["IdTipoSala"] = new SelectList(_context.TipoSala, "IdTipoSala", "NomeSala", sala.IdTipoSala);
            return View(sala);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdSala,TempoPreparação,HoraInicio,HoraFim,IdTipoSala")] Sala sala)
        {
            if (id != sala.IdSala) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Sala.Any(e => e.IdSala == id)) return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["IdTipoSala"] = new SelectList(_context.TipoSala, "IdTipoSala", "NomeSala", sala.IdTipoSala);
            return View(sala);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();

            var sala = await _context.Sala.Include(s => s.TipoSala)
                            .FirstOrDefaultAsync(m => m.IdSala == id);

            if (sala == null) return NotFound();

            return View(sala);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sala = await _context.Sala.FindAsync(id);

            if (sala != null) _context.Sala.Remove(sala);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
