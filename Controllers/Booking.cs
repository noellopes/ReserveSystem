using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;

namespace ReserveSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public BookingController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // Alteração: Agora o trainerId será passado como parte da URL e não como query string
        // GET: Booking/Index/5
        public async Task<IActionResult> Index(int? id)  // Alterado o parâmetro para 'id'
        {
            if (id == null)
            {
                return NotFound("O ID do espaço não foi fornecido.");
            }

            // Obter o Personal Trainer
            var trainer = await _context.PersonalTrainer
                                        .FirstOrDefaultAsync(t => t.Id == id);

            if (trainer == null)
            {
                return NotFound("Personal Trainer não encontrado.");
            }

            // Obter os horários do espaço
            var bookings = await _context.Reserva
                .Where(h => h.PersonalTrainerId == id)
                .Include(h => h.Client) // Inclui o Client na consulta
                .OrderBy(h => h.StartTime)
                .ToListAsync();


            // Obter o espaço específico
            var space = await _context.Spaces.FirstOrDefaultAsync(s => s.Id == id);
            if (space == null)
            {
                return NotFound("Espaço não encontrado.");
            }

            ViewData["TrainerName"] = trainer.Name;

            return View(bookings);
        }
    }
}
