using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Added for logging
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ReservasController> _logger; // Added for logging


        public ReservasController(ApplicationDbContext context, ILogger<ReservasController> logger)
        {
            _context = context;
            _logger = logger; // Agora, o logger é inicializado corretamente
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Reserva.Include(b => b.Prato).Include(c => c.Cliente);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva

                .Include(b => b.Prato).Include(c => c.Cliente)

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
            ViewData["IdCliente"] = new SelectList(_context.Cliente?.ToList() ?? new List<Cliente>(), "IdCliente", "NomeCliente");
            ViewData["IdPrato"] = new SelectList(_context.Prato?.ToList() ?? new List<Prato>(), "IdPrato", "PratoNome");

            
            return View();
        }


        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]//REFACTORED
        public async Task<IActionResult> Create([Bind("IdReserva,IdCliente, NumeroPessoas,DataHora,Observacao,IdPrato")] Reserva reserva)
        {
            int maximoLugar = _context.Mesa.Max(t => t.NumeroLugares);


            int? idMesa = _context.Mesa
            .Where(t => t.NumeroLugares == maximoLugar)
            .Select(t => t.IdMesa)
            .FirstOrDefault();

            if (reserva.NumeroPessoas > maximoLugar)
            {
                ModelState.AddModelError("NumeroPessoas", $"O número de pessoas ({reserva.NumeroPessoas}) excede o máximo permitido ({maximoLugar}).");
            }

            
            if (ModelState.IsValid)
            {
                if (idMesa != null)
                {
                    reserva.IdMesa = idMesa.Value; 
                }

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "NomeCliente", reserva.IdCliente);
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome", reserva.IdPrato);
            return View(reserva);
        }
        //REFACTORED
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,IdCliente, NumeroPessoas,DataHora,Observacao,IdPrato")] Reserva reserva)

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

                    // Provide user feedback (Optional)
                    ModelState.AddModelError(string.Empty, "A concurrency error occurred. Please try again.");
                    return View(reserva);
                }
                catch (DbUpdateException ex)
                {
                    // Log the exception details
                    _logger.LogError($"Error while updating reservation: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        _logger.LogError($"Inner exception: {ex.InnerException.Message}");
                    }

                    // Provide user feedback (Optional)
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the reservation. Please try again.");
                    return View(reserva);
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

                .Include(b => b.Prato).Include(c => c.Cliente)

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

            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.IdReserva == id);
        }
    }
}