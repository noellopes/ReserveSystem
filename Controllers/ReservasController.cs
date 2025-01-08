using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace ReserveSystem.Controllers {
    public class ReservasController : Controller {
        private readonly ReserveSystemContext _context;
        


        public ReservasController(ReserveSystemContext context ) {
            _context = context;
        
        }

        // GET: Reservas
        public async Task<IActionResult> Index(int page = 1, string searchCliente = "", string searchPrato = "") {
            var reservas = from r in _context.Reserva.Include(r => r.Cliente).Include(r => r.Prato) select r;

            if (searchCliente != "")
            {
                reservas = from r in reservas where r.Cliente!.NomeCliente.Contains(searchCliente) select r;
            }

            if (searchPrato != "")
            {
                reservas = from r in reservas where r.Prato!.PratoNome.Contains(searchPrato) select r;
            }

            var model = new ReservasViewModel();

            model.PagingInfo = new PagingInfo {
                CurrentPage = page,
                TotalItems = await reservas.CountAsync(),
            };

            model.Reservas = reservas.ToList();

            model.Reservas = await reservas
                    .OrderBy(r => r.Cliente)
                    .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.PageSize)
                    .Take(model.PagingInfo.PageSize)
                    .ToListAsync();

            model.SearchCliente = searchCliente;
            model.SearchPrato = searchPrato;

            return View(model);
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Prato).Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null) {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create(DateTime? DataHora) {
            var data = DataHora ?? DateTime.Now;
            var diaReserva = data.DayOfWeek;


            var pratosDoDia = _context.Prato
                .Where(p => p.Dia == diaReserva)
                .ToList();

            ViewBag.IdPrato = new SelectList(pratosDoDia, "IdPrato", "PratoNome");
            ViewBag.IdCliente = new SelectList(_context.Cliente, "IdCliente", "NomeCliente");

            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]//REFACTORED
        public async Task<IActionResult> Create([Bind("IdReserva,IdCliente,NumeroPessoas,DataHora,Observacao,IdPrato")] Reserva reserva, DateTime? Dia) {
            if (!_context.Mesa.Any()) {
                ModelState.AddModelError("", "Não existem mesas disponíveis no momento.");
            } else {
                int maximoLugar = _context.Mesa.Max(t => t.NumeroLugares);

                if (reserva.NumeroPessoas > maximoLugar) {
                    ModelState.AddModelError("NumeroPessoas", $"O número de pessoas ({reserva.NumeroPessoas}) excede o máximo de lugares disponíveis ({maximoLugar}).");
                } else {

                    int? idMesa = _context.Mesa
                        .Where(t => t.NumeroLugares >= reserva.NumeroPessoas)
                        .Where(t => t.Reservado != true)
                        .OrderBy(t => t.NumeroLugares)
                        .Select(t => t.IdMesa)
                        .FirstOrDefault();


                    if (idMesa != null) {

                        var mesaSelecionada = _context.Mesa.FirstOrDefault(t => t.IdMesa == idMesa.Value);

                        if (mesaSelecionada == null) {
                            ModelState.AddModelError("IdMesa", "Nenhuma mesa se encontra disponivel de momento por favor tente noutro horário.");
                        } else {
                            reserva.IdMesa = mesaSelecionada.IdMesa;
                            reserva.NumeroMesa = mesaSelecionada.IdMesa;

                            mesaSelecionada.Reservado = true;
                            _context.Update(mesaSelecionada);
                        }
                    } else {
                        ModelState.AddModelError("", "Nenhuma mesa disponível suporta o número de pessoas especificado. Por favor, tente em outro horário.");
                    }
                }
            }

            if (ModelState.IsValid) {
                    var mesaReservada = await _context.Mesa.FindAsync(reserva.IdMesa);
                    if (mesaReservada != null) {
                        mesaReservada.Reservado = true;
                        _context.Update(mesaReservada);
                    } else {
                        ModelState.AddModelError("", "De momento todas as mesas estão reservadas por favor tente noutro horário");
                    }

                    _context.Add(reserva);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Reserva criada com sucesso!";
            }

            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NomeCliente", reserva.IdCliente);
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome", reserva.IdPrato);
            return View(reserva);
        }
        //REFACTORED
        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null) {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NomeCliente", reserva.IdCliente);
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome", reserva.IdPrato);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,IdCliente,IdMesa,NumeroPessoas,DataHora,Observacao,IdPrato, Aprovacao")] Reserva reserva) {
            if (id != reserva.IdReserva) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Reserva criada com sucesso!";
                } catch (DbUpdateConcurrencyException) {
                    if (!ReservaExists(reserva.IdReserva)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome", reserva.IdPrato);

            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Prato).Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null) {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null) {
                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();


            }

            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id) {
            return _context.Reserva.Any(e => e.IdReserva == id);
        }
    }
}
