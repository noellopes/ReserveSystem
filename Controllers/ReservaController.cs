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

        [HttpGet]
        public async Task<IActionResult> GetSpaceHours(int spaceId, string date)
        {
            var parsedDate = DateTime.Parse(date);
            var dayOfWeek = parsedDate.DayOfWeek;

            var space = await _context.Spaces.FindAsync(spaceId);
            if (space == null)
            {
                return NotFound(new { message = "Espaço não encontrado." });
            }

            var horario = await _context.HorarioModel
                .FirstOrDefaultAsync(h => h.spaceId == spaceId && h.Day == dayOfWeek);

            if (horario == null || horario.IsClosed)
            {
                return Json(new { isClosed = true, spaceName = space.Name });
            }

            return Json(new
            {
                isClosed = false,
                spaceName = space.Name,
                dayOfWeek = horario.Day.ToString(),
                openTime = horario.OpenTime.ToString(@"hh\:mm"),
                closeTime = horario.CloseTime.ToString(@"hh\:mm")
            });
        }



        // GET: WorkoutSchedule/Index
        public async Task<IActionResult> Index()
        {
            var schedules = _context.Reserva
                .Include(ws => ws.PersonalTrainer)
                .Include(ws => ws.Client)
                .Include(ws => ws.Space); // Inclua o espaço, se necessário
            return View(await schedules.ToListAsync());
        }

        // GET: WorkoutSchedule/Create
        public async Task<IActionResult> Create()
        {
            // Carrega Personal Trainers e Clientes
            ViewData["Spaces"] = await _context.Spaces.ToListAsync() ?? new List<SpaceModel>();
            ViewData["PersonalTrainers"] = await _context.PersonalTrainer.ToListAsync() ?? new List<PersonalTrainerModel>();
            ViewData["Clients"] = await _context.Client.ToListAsync() ?? new List<ClientModel>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservaModel reserva)
        {
            // Log para depuração: verificar os dados recebidos
            Console.WriteLine("Dados recebidos na criação da reserva:");
            Console.WriteLine($"PersonalTrainerId: {reserva.PersonalTrainerId}");
            Console.WriteLine($"ReservationDate: {reserva.ReservationDate}");
            Console.WriteLine($"StartTime: {reserva.StartTime}");
            Console.WriteLine($"EndTime: {reserva.EndTime}");
            Console.WriteLine($"ClientId: {reserva.ClientId}");
            Console.WriteLine($"SpaceId: {reserva.SpaceId}");
            // Verificar se o PersonalTrainerId é válido, caso tenha sido selecionado
            if (reserva.PersonalTrainerId.HasValue)
            {
                var personalTrainer = _context.PersonalTrainer.Find(reserva.PersonalTrainerId.Value);
                if (personalTrainer == null)
                {
                    ModelState.AddModelError("PersonalTrainerId", "O Personal Trainer selecionado não é válido.");
                }
            }

            // Verificar se a data é válida
            if (reserva.ReservationDate < DateTime.Today)
            {
                ModelState.AddModelError("ReservationDate", "A data da reserva não pode ser no passado.");
            }

            // Verificar se o horário final é maior que o inicial
            if (reserva.StartTime >= reserva.EndTime)
            {
                ModelState.AddModelError("EndTime", "O horário de término deve ser após o horário de início.");
            }

            // Verificar o intervalo mínimo de 30 minutos
            if ((reserva.EndTime - reserva.StartTime).TotalMinutes < 30)
            {
                ModelState.AddModelError("EndTime", "O intervalo mínimo entre os horários deve ser de 30 minutos.");
            }


            // Verificar o intervalo máximo de 3 horas
            if ((reserva.EndTime - reserva.StartTime).TotalHours > 3)
            {
                ModelState.AddModelError("EndTime", "O intervalo máximo entre os horários deve ser de 3 horas.");
            
            }

            // Retorna à view se houver erros de validação
            if (!ModelState.IsValid)
            {
                // Recarregar listas de espaços, personal trainers e clientes para a view
                ViewData["Spaces"] = _context.Spaces.ToList();
                ViewData["PersonalTrainers"] = _context.PersonalTrainer.ToList();
                ViewData["Clients"] = _context.Client.ToList();
                return View(reserva);
            }

            // Salvar a reserva
            _context.Reserva.Add(reserva);
            _context.SaveChanges();

            TempData["messageToast"] = "Reserva criada com sucesso";

            return RedirectToAction(nameof(Index));
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
            if (schedule != null)
            {
                _context.Reserva.Remove(schedule);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> GetPersonalTrainersBySpecialty(string specialties)
        {
            try
            {
                // Transforma a string de especialidades separadas por vírgula em uma lista de enums
                var specialtyList = specialties.Split(',').Select(s => Enum.TryParse<TrainerSpecialty>(s, out var specialty) ? specialty : (TrainerSpecialty?)null).Where(s => s.HasValue).ToList();

                if (!specialtyList.Any())
                {
                    return BadRequest(new { message = "Nenhuma especialidade válida foi fornecida." });
                }

                // Busca os personal trainers que têm as especialidades selecionadas
                var trainers = await _context.PersonalTrainer
                    .Where(pt => pt.Specialties.Any(s => specialtyList.Contains(s)))
                    .Select(pt => new
                    {
                        pt.Id,
                        pt.Name,
                        pt.Email,
                        Specialties = pt.Specialties.Select(s => s.ToString()).ToList()
                    })
                    .ToListAsync();

                if (trainers == null || !trainers.Any())
                {
                    return Json(new { message = "Nenhum Personal Trainer encontrado para a especialidade selecionada." });
                }

                // Certifique-se de que estamos retornando um array válido
                return Json(trainers);  // Aqui a resposta é um array
            }
            catch (Exception ex)
            {
                // Log o erro para depuração e retorne uma resposta amigável
                Console.WriteLine($"Erro ao buscar Personal Trainers: {ex.Message}");
                return StatusCode(500, new { message = "Ocorreu um erro ao tentar buscar os Personal Trainers. Tente novamente mais tarde." });
            }
        }


    }




}

