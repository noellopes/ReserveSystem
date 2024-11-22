using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public ReservaController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutSchedule/Index
        public async Task<IActionResult> Index()
        {
            var schedules = _context.Reserva
                .Include(ws => ws.PersonalTrainer)
                .Include(ws => ws.Client);
            return View(await schedules.ToListAsync());
        }

        // GET: WorkoutSchedule/Create
        public async Task<IActionResult> Create()
        {
            // Carrega Personal Trainers e Clientes
            ViewData["PersonalTrainers"] = await _context.PersonalTrainer.ToListAsync();
            ViewData["Clients"] = await _context.Client.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservaModel reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Caso a validação falhe, recarregue os dados para os dropdowns
            ViewData["PersonalTrainers"] = await _context.PersonalTrainer.ToListAsync();
            ViewData["Clients"] = await _context.Client.ToListAsync();
            return View(reserva);
        }


        // GET: WorkoutSchedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Reserva
                .Include(ws => ws.PersonalTrainer)
                .Include(ws => ws.Client)
                .FirstOrDefaultAsync(ws => ws.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: WorkoutSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
