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
    public class ReservaController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ReservaController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.ReservaModel.Include(r => r.Cliente);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReservaID == id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            return View(reservaModel);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "Email");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaID,TipoReserva,DataReserva,DataInicio,DataFim,Partcipantes,PrecoTotal,ClienteId")] ReservaModel reservaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "Email", reservaModel.ClienteId);
            return View(reservaModel);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel.FindAsync(id);
            if (reservaModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "Email", reservaModel.ClienteId);
            return View(reservaModel);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaID,TipoReserva,DataReserva,DataInicio,DataFim,Partcipantes,PrecoTotal,ClienteId")] ReservaModel reservaModel)
        {
            if (id != reservaModel.ReservaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaModelExists(reservaModel.ReservaID))
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "Email", reservaModel.ClienteId);
            return View(reservaModel);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaModel = await _context.ReservaModel
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReservaID == id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            return View(reservaModel);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaModel = await _context.ReservaModel.FindAsync(id);
            if (reservaModel != null)
            {
                _context.ReservaModel.Remove(reservaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaModelExists(int id)
        {
            return _context.ReservaModel.Any(e => e.ReservaID == id);
        }
    }
}
