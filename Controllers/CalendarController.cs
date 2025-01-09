using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public CalendarController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: Calendar/Index/5
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound("O ID do espaço não foi fornecido.");
            }

            // Obter o espaço específico
            var space = await _context.Spaces.FirstOrDefaultAsync(s => s.Id == id);
            if (space == null)
            {
                return NotFound("Espaço não encontrado.");
            }

            // Obter os horários do espaço
            var horarios = await _context.HorarioModel
                .Where(h => h.spaceId == id)
                .OrderBy(h => h.Day)
                .ToListAsync();

            ViewData["SpaceName"] = space.Name;
            ViewData["SpaceId"] = space.Id;

            return View(horarios);
        }

        // GET: Calendar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("O ID do horário não foi fornecido.");
            }

            var horario = await _context.HorarioModel.FirstOrDefaultAsync(h => h.Id == id);
            if (horario == null)
            {
                return NotFound("Horário não encontrado.");
            }
            TempData["messageToast"] = "Horário atualizado com sucesso";
            return View(horario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HorarioModel horario)
        {

            Console.WriteLine("Chegou ao controller!");
            if (id != horario.Id)
            {
                return NotFound("O ID fornecido não corresponde ao horário.");
            }
            Console.WriteLine("Chegou ao controller! 2");
            var horarioAtual = await _context.HorarioModel
                .FirstOrDefaultAsync(h => h.Id == id);

            if (horarioAtual == null)
            {
                return NotFound("Horário não encontrado.");
            }

            Console.WriteLine("Chegou ao controller! 3");

            // Imprimir as propriedades do modelo que estão sendo passadas para o controlador
            Console.WriteLine($"IsClosed: {horario.IsClosed}");
            Console.WriteLine($"OpenTime: {horario.OpenTime}");
            Console.WriteLine($"CloseTime: {horario.CloseTime}");
            Console.WriteLine($"SpaceID: {horario.spaceId}");


            // Se estiver fechado, zera os horários
            if (horario.IsClosed)
            {
                Console.WriteLine("Chegou ao controller! 4");
                horario.OpenTime = TimeSpan.Zero;
                horario.CloseTime = TimeSpan.Zero;
            }
            else
            {
                Console.WriteLine("Chegou ao controller! 5");
                // Validação customizada para horário de fechamento
                if (!horario.ValidateCloseTime())
                {
                    Console.WriteLine("Bateu aqui");
                    ModelState.AddModelError("CloseTime", "Horário de fechamento deve ser maior que horário de abertura.");
                    return View(horario);
                }
            }
            // Imprimir todos os erros no ModelState para diagnóstico
            Console.WriteLine("ModelState Errors:");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Erro: {error.ErrorMessage}");
            }

            Console.WriteLine("Chegou ao controller! 6");
            if (ModelState.IsValid)
            {
                Console.WriteLine("Chegou ao controller! 7");
                try
                {
                    // Atualiza propriedades
                    horarioAtual.IsClosed = horario.IsClosed;
                    horarioAtual.OpenTime = horario.OpenTime;
                    horarioAtual.CloseTime = horario.CloseTime;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { id = horarioAtual.spaceId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao salvar as alterações.");
                    return View(horario);
                }
            }

            return View(horario);
        }

    }
}
