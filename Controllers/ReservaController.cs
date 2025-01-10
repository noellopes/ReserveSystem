using Microsoft.AspNetCore.Http;
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

        // GET: ReservaController
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reserva
                .Include(r => r.TipoReserva)
                .Include(r => r.Client)
                .ToListAsync();
            return View(reservas);
        }

        // GET: ReservaController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var reserva = await _context.Reserva
                .Include(r => r.TipoReserva)
                .Include(r => r.Client)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // GET: ReservaController/Create
        public IActionResult Create()
        {
            PopulateViewData();
            return View();
        }

        // POST: ReservaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva model)
        {
            if (ModelState.IsValid)
            {
                model.DataReserva = DateTime.Now; // Set the current date and time
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateViewData();
            return View(model);
        }

        // GET: ReservaController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            PopulateViewData();
            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Reserva model)
        {
            if (id != model.IdReserva)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(model.IdReserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateViewData();
            return View(model);
        }

        // GET: ReservaController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var reserva = await _context.Reserva
                .Include(r => r.TipoReserva)
                .Include(r => r.Client)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: ReservaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateViewData()
        {
            var tipoReservaList = _context.TipoReserva
                .Select(tr => new SelectListItem
                {
                    Value = tr.idTipoReserva.ToString(),
                    Text = tr.NomeReserva
                }).ToList();

            tipoReservaList.Insert(0, new SelectListItem { Value = "", Text = "-- Choose Type -- " });

            ViewData["ClientId"] = new SelectList(_context.ClientModel, "ClienteId", "NomeCliente");

            var EquipamentoList = _context.Equipamento
                .Select(te => new SelectListItem
                {
                    Value = te.IdEquipamento.ToString(),
                    Text = te.NomeEquipamento
                }).ToList();

            EquipamentoList.Insert(0, new SelectListItem { Value = "", Text = "-- Choose Equipment -- " });

            ViewData["TipoEquipamento"] = EquipamentoList;
        }
        private bool ReservaExists(long id)
        {
            return _context.Reserva.Any(e => e.IdReserva == id);
        }
    }
}
