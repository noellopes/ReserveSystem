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
    public class MotoristaTransportesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public MotoristaTransportesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: MotoristaTransportes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MotoristaTransporte.ToListAsync());
        }

        // GET: MotoristaTransportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motoristaTransporte = await _context.MotoristaTransporte
                .FirstOrDefaultAsync(m => m.MotoristaTransporteId == id);
            if (motoristaTransporte == null)
            {
                return NotFound();
            }

            return View(motoristaTransporte);
        }

        // GET: MotoristaTransportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotoristaTransportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotoristaTransporteId,StaffId,TransporteId")] MotoristaTransporte motoristaTransporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motoristaTransporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motoristaTransporte);
        }

        // GET: MotoristaTransportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motoristaTransporte = await _context.MotoristaTransporte.FindAsync(id);
            if (motoristaTransporte == null)
            {
                return NotFound();
            }
            return View(motoristaTransporte);
        }

        // POST: MotoristaTransportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotoristaTransporteId,StaffId,TransporteId")] MotoristaTransporte motoristaTransporte)
        {
            if (id != motoristaTransporte.MotoristaTransporteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motoristaTransporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaTransporteExists(motoristaTransporte.MotoristaTransporteId))
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
            return View(motoristaTransporte);
        }

        // GET: MotoristaTransportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motoristaTransporte = await _context.MotoristaTransporte
                .FirstOrDefaultAsync(m => m.MotoristaTransporteId == id);
            if (motoristaTransporte == null)
            {
                return NotFound();
            }

            return View(motoristaTransporte);
        }

        // POST: MotoristaTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motoristaTransporte = await _context.MotoristaTransporte.FindAsync(id);
            if (motoristaTransporte != null)
            {
                _context.MotoristaTransporte.Remove(motoristaTransporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaTransporteExists(int id)
        {
            return _context.MotoristaTransporte.Any(e => e.MotoristaTransporteId == id);
        }
    }
}
