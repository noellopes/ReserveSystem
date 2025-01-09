using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class SpaceController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;
        public SpaceController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }
        // GET: Space/Index
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.Spaces.ToListAsync());
            }
            catch (Exception ex)
            {
                // Registra o erro
                Console.WriteLine(ex.Message);
                return View("Error"); // Certifique-se de ter uma View de erro.
            }
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            // Cria uma lista de itens para o dropdown baseado no enum SpaceType
            ViewBag.SpaceTypes = Enum.GetValues(typeof(SpaceType))
                                     .Cast<SpaceType>()
                                     .Select(e => new SelectListItem
                                     {
                                         Value = e.ToString(), // Valor que será enviado no formulário
                                         Text = e.ToString()   // Texto exibido no dropdown
                                     })
                                     .ToList();
            // Inicializa o modelo com valores padrão
            var model = new SpaceModel
            {
                Name = string.Empty,       // Nome inicial vazio
                Capacity = 0,              // Capacidade inicial
                ReservedPercentage = 0,    //Percentagem inicial
                Type = SpaceType.GYM       // Tipo inicial configurado como GYM
            };

            // Passa o modelo para a View
            return View(model);
        }

        // POST: Space/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpaceModel space)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Salva o espaço no banco de dados
                    _context.Add(space);
                    await _context.SaveChangesAsync(); // Certifique-se de salvar antes de usar o ID gerado

                    // Criar horários padrão
                    var horarios = new List<HorarioModel>
            {
                new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Monday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0), IsClosed=false },
                new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Tuesday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0),IsClosed=false },
                new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Wednesday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0),IsClosed=false },
                new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Thursday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0),IsClosed=false },
                new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Friday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0),IsClosed=false },
                new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Saturday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0),IsClosed=false },
                new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Sunday, OpenTime = new TimeSpan(0, 0, 0), CloseTime = new TimeSpan(0, 0, 0),IsClosed=true } // Domingo fechado
            };

                    // Adiciona os horários ao contexto
                    _context.HorarioModel.AddRange(horarios);

                    // Salva as alterações no banco de dados
                    await _context.SaveChangesAsync();

                    TempData["messageToast"] = "Espaço criado com sucesso!";

                    // Redireciona para a página de índice
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Lida com possíveis erros
                    Console.WriteLine($"Erro ao criar o espaço: {ex.Message}");
                    ModelState.AddModelError("", "Ocorreu um erro ao criar o espaço. Tente novamente.");
                }

            }

            // Se o ModelState for inválido ou ocorrer erro, retorna a view de criação
            return View(space);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var space = await _context.Spaces.FirstOrDefaultAsync(c => c.Id == id);
            if (space == null)
            {
                return NotFound();
            }

            return View(space);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var space = await _context.Spaces.FindAsync(id);
            _context.Spaces.Remove(space);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Space/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var space = await _context.Spaces.FirstOrDefaultAsync(m => m.Id == id);
            if (space == null)
            {
                return NotFound();
            }

            return View(space);
        }

        // GET: Space/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var space = await _context.Spaces.FindAsync(id);
            if (space == null)
            {
                return NotFound();
            }

            ViewBag.SpaceTypes = Enum.GetValues(typeof(SpaceType))
                                     .Cast<SpaceType>()
                                     .Select(e => new SelectListItem
                                     {
                                         Value = e.ToString(),
                                         Text = e.ToString()
                                     })
                                     .ToList();

            return View(space);
        }

        // POST: Space/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpaceModel space)
        {
            if (id != space.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(space);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Spaces.Any(e => e.Id == space.Id))
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

            ViewBag.SpaceTypes = Enum.GetValues(typeof(SpaceType))
                                     .Cast<SpaceType>()
                                     .Select(e => new SelectListItem
                                     {
                                         Value = e.ToString(),
                                         Text = e.ToString()
                                     })
                                     .ToList();

            return View(space);
        }

    }
}
