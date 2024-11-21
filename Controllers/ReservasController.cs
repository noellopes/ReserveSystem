using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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


        public ReservasController(ApplicationDbContext context)

        {
            _context = context;
            _logger = logger; // Initialize logger
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Reserva.Include(b => b.Prato);
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

                .Include(b => b.Prato)

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
            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome");
            return View();
        }


        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,NomeCliente,NumeroMesa,NumeroPessoas,DataHora,Observacao,IdPrato")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

            ViewData["IdPrato"] = new SelectList(_context.Prato, "IdPrato", "PratoNome", reserva.IdPrato);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,NomeCliente,NumeroMesa,NumeroPessoas,DataHora,Observacao,IdPrato")] Reserva reserva)

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

                .Include(b => b.Prato)

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