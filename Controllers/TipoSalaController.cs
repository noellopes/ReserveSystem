using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TipoSalasController : Controller
    {
        private readonly ReserveSystemContext _context;

        public TipoSalasController(ReserveSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoSala.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TipoSala.FirstOrDefaultAsync(m => m.IdTipoSala == id);

            if (tipoSala == null) return NotFound();

            return View(tipoSala);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoSala,NomeSala,TamanhoSala,Capacidade,PreçoHora")] TipoSala tipoSala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tipoSala);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TipoSala.FindAsync(id);

            if (tipoSala == null) return NotFound();

            return View(tipoSala);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdTipoSala,NomeSala,TamanhoSala,Capacidade,PreçoHora")] TipoSala tipoSala)
        {
            if (id != tipoSala.IdTipoSala) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TipoSala.Any(e => e.IdTipoSala == id)) return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(tipoSala);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();

            var tipoSala = await _context.TipoSala.FirstOrDefaultAsync(m => m.IdTipoSala == id);

            if (tipoSala == null) return NotFound();

            return View(tipoSala);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tipoSala = await _context.TipoSala.FindAsync(id);

            if (tipoSala != null) _context.TipoSala.Remove(tipoSala);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
