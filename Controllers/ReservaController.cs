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
            //var reserveSystemContext = _context.ReservaModel.Include(r => r.ClienteId);
            return View(await _context.ReservaModel.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Reserva = await _context.ReservaModel
                .Include(r => r.ClienteId)
                .FirstOrDefaultAsync(m => m.ReservaID == id);
            if (Reserva == null)
            {
                return NotFound();
            }

            return View(Reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            //ViewData["ClienteId"] = new SelectList(_context.ReservaModel, "ClienteId");
            var clienteIds = _context.ClientModel.Select(r => r.ClienteId).ToList();
            ViewData["ClienteId"] = new SelectList(clienteIds);

            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaID,TipoReserva,DataReserva,DataInicio,DataFim,Partcipantes,PrecoTotal,ClienteId")] ReservaModel Reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ClienteId"] = new SelectList(_context.ClientModel, "ClienteId", "Email", ReservaModel.C);
            return View(Reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Reserva = await _context.ReservaModel.FindAsync(id);
            if (Reserva == null)
            {
                return NotFound();
            }
            //ViewData["ClienteId"] = new SelectList(_context.ClientModel, "ClienteId", "Email", ReservaModel.ClienteId);
            return View(Reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaID,TipoReserva,DataReserva,DataInicio,DataFim,Partcipantes,PrecoTotal,ClienteId")] ReservaModel Reserva)
        {
            if (id != Reserva.ReservaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(Reserva.ReservaID))
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
            //ViewData["ClienteId"] = new SelectList(_context.ClientModel, "ClienteId", "Email", reservaModel.ClienteId);
            return View(Reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Reserva = await _context.ReservaModel
                .Include(r => r.ClienteId)
                .FirstOrDefaultAsync(m => m.ReservaID == id);
            if (Reserva == null)
            {
                return NotFound();
            }

            return View(Reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Reserva = await _context.ReservaModel.FindAsync(id);
            if (Reserva != null)
            {
                _context.ReservaModel.Remove(Reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.ReservaModel.Any(e => e.ReservaID == id);
        }
    }
}
