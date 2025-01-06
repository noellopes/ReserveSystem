using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace ReserveSystem.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index(int page = 1, string searchCliente = "", string searchPrato = "")
        {
            var reservas = from r in _context.Reserva.Include(r => r.Cliente).Include(r => r.Prato) select r;

            //if (searchCliente != "")
            //{
            //    reservas = from r in reservas where r.Cliente!.NomeCliente.Contains(searchCliente) select r;
            //}

            //if (searchPrato != "")
            //{
            //    reservas = from r in reservas where r.Prato!.PratoNome.Contains(searchPrato) select r;
            //}

            var model = new ReservasViewModel();

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = await reservas.CountAsync(),
            };

            model.Reservas = reservas.ToList();

            //model.Reservas = await reservas
            //        .OrderBy(r => r.Cliente)
            //        .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.PageSize)
            //        .Take(model.PagingInfo.PageSize)
            //        .ToListAsync();

            model.SearchCliente = searchCliente;
            model.SearchPrato = searchPrato;

            return View(model);
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Prato).Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NomeCliente");
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome");
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,IdCliente,NumeroPessoas,DataHora,Observacao,IdPrato")] Reserva reserva)
        {
            if (!_context.Mesa.Any())
            {
                ModelState.AddModelError("", "Não existem mesas disponíveis no momento.");
            }
            else
            {
                int maximoLugar = _context.Mesa.Max(t => t.NumeroLugares);

                if (reserva.NumeroPessoas > maximoLugar)
                {
                    ModelState.AddModelError("NumeroPessoas", $"O número de pessoas ({reserva.NumeroPessoas}) excede o máximo de lugares disponíveis ({maximoLugar}).");
                }
                else
                {
                    int? idMesa = _context.Mesa
                        .Where(t => t.NumeroLugares >= reserva.NumeroPessoas)
                        .OrderBy(t => t.NumeroLugares)
                        .Select(t => t.IdMesa)
                        .FirstOrDefault();

                    if (idMesa != null)
                    {
                        reserva.IdMesa = idMesa.Value;
                        reserva.NumeroMesa = idMesa.Value;
                    }
                    else
                    {
                        ModelState.AddModelError("IdMesa", "Nenhuma mesa disponível suporta o número de pessoas especificado.");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NomeCliente", reserva.IdCliente);
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome", reserva.IdPrato);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NomeCliente", reserva.IdCliente);
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome", reserva.IdPrato);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,IdCliente,IdMesa,NumeroPessoas,DataHora,Observacao,IdPrato")] Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IdReserva))
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
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome", reserva.IdPrato);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Prato).Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.IdReserva == id);
        }
    }
}
