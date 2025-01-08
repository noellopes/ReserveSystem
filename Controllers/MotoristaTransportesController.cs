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
        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 10)
        {
            // Filtragem
            var motoristaTransporteQuery = _context.MotoristaTransporte
                .Include(t => t.Staff)
                .Include(t => t.Transporte)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                motoristaTransporteQuery = motoristaTransporteQuery.Where(mt =>
                    mt.Staff.Staff_Name.Contains(searchString) ||
                    mt.Transporte.TipoTransporte.Contains(searchString));
            }

            // Paginação
            int totalItems = await motoristaTransporteQuery.CountAsync();
            var motoristaTransporte = await motoristaTransporteQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Criação do objeto PageInfo
            var pageInfo = new PageInfo
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = page
            };

            // Passa os dados para a View usando ViewBag e ViewData
            ViewData["SearchString"] = searchString;
            ViewBag.PageInfo = pageInfo;

            return View(motoristaTransporte);
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
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Staff_Name");
            ViewData["TransporteId"] = new SelectList(_context.Transporte, "TransporteId", "TipoTransporte");
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
            if (_context.MotoristaTransporte.Any(mt => mt.TransporteId == id))
            {
                return BadRequest("O transporte está vinculado a um motorista e não pode ser excluído.");
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
