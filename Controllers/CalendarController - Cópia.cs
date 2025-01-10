using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

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
        public async Task<IActionResult> Index(int id)  // Alterado o parâmetro para 'id'
        {
            // Buscar o Personal Trainer pelo ID
            var trainer = await _context.PersonalTrainer
                                        .FirstOrDefaultAsync(t => t.Id == id);

            if (trainer == null)
            {
                return NotFound();
            }

            // Buscar as marcações associadas a esse Personal Trainer
            var bookings = await _context.Reserva
                                         .Where(r => r.PersonalTrainerId == id)
                                         .Include(r => r.Client)
                                         .Include(r => r.Space)
                                         .OrderBy(r => r.ReservationDate)
                                         .ThenBy(r => r.StartTime)
                                         .ToListAsync();

            // Criar o ViewModel para passar os dados para a View
            var viewModel = new PersonalTrainerBookingsViewModel
            {
                Trainer = trainer,
                Bookings = bookings
            };

            return View(viewModel);
        }
    }
}
