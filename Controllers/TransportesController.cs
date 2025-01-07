using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TransportesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public TransportesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Transportes
        public async Task<IActionResult> Index()
        {

            return View(await _context.Transporte.ToListAsync());
        }

        // GET: Transportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transporte
                .FirstOrDefaultAsync(m => m.TransporteId == id);
            if (transporte == null)
            {
                return NotFound();
            }

            return View(transporte);
        }

        // GET: Transportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransporteId,Matricula,Capacidade,CartaTransporte,TipoTransporte,AnoFabricacao,DescricaoTipoTransporte")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transporte);


        }


        // GET: Transportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            if (id == null || id <= 0)
            {
                return NotFound("ID inválido");
            }

            var transporte = await _context.Transporte.FindAsync(id);
            if (transporte == null)
            {
                return NotFound("O transporte não foi encontrado");
            }
            return View(transporte);

        }

        // POST: Transportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransporteId,Matricula,Capacidade,TipoTransporte,AnoFabricacao,DescricaoTipoTransporte")] Transporte transporte)
        {
            if (id != transporte.TransporteId)
            {
                return NotFound("ID inválido");
            }
            if (_context.Transporte.Any(t => t.TransporteId != id && t.Matricula == transporte.Matricula))
            {
                ModelState.AddModelError("Matricula", "Já existe um transporte com essa matrícula.");
            }

            if (!ModelState.IsValid)
            {
                return View(transporte);
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransporteExists(transporte.TransporteId))
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
            return View(transporte);
        }

        // GET: Transportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transporte
                .FirstOrDefaultAsync(m => m.TransporteId == id);
            if (transporte == null)
            {
                return NotFound();
            }

            return View(transporte);
        }

        // POST: Transportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transporte = await _context.Transporte.FindAsync(id);
            if (transporte != null)
            {
                _context.Transporte.Remove(transporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransporteExists(int id)
        {
            return _context.Transporte.Any(e => e.TransporteId == id);
        }
    }
}
