using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Room
        public IActionResult Index(string roomSearchQuery)
        {
            var rooms = _context.Room.Include(r => r.RoomType).AsQueryable(); // Inclui RoomType associado ao Room

            // Filtra pela pesquisa, se houver
            if (!string.IsNullOrEmpty(roomSearchQuery))
            {
                // Verifica se o valor de pesquisa é numérico
                if (int.TryParse(roomSearchQuery, out int roomNumber))
                {
                    rooms = rooms.Where(r => r.ID_ROOM == roomNumber); // Pesquisa pelo número do quarto (ID_ROOM)
                }
                else
                {
                    rooms = rooms.Where(r => r.RoomType.Type.Contains(roomSearchQuery)); // Pesquisa pelo tipo de quarto
                }
            }

            // Passa o modelo correto para a View (IEnumerable<Room>)
            return View(rooms.ToList());
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Carregar o Room junto com o RoomType
            var roomModel = await _context.Room
                .Include(r => r.RoomType)  // Carregar a propriedade RoomType associada
                .FirstOrDefaultAsync(m => m.ID_ROOM == id);

            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            try
            {
                var roomTypes = _context.RoomType.ToList();

                if (!roomTypes.Any())
                {
                    TempData["ErrorMessage"] = "Nenhum tipo de quarto está disponível. Por favor, adicione tipos de quarto antes de criar um quarto.";
                    return RedirectToAction("Index");
                }

                // Passa os tipos de quarto (ID e Nome) para a view
                ViewData["RoomTypeId"] = new SelectList(roomTypes, "RoomTypeId", "Type");
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao carregar tipos de quarto: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_ROOM,RoomTypeId,HasView,AcessibilityRoom")] RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Adiciona o novo quarto ao banco de dados
                    _context.Add(roomModel);
                    await _context.SaveChangesAsync();

                    // Se o quarto for criado com sucesso, exibe uma mensagem de sucesso
                    TempData["SuccessMessage"] = "Quarto criado com sucesso!";
                    return RedirectToAction(nameof(Index)); // Redireciona para a lista de quartos
                }
                catch (Exception ex)
                {
                    // Se houver um erro ao criar o quarto, exibe uma mensagem de erro
                    TempData["ErrorMessage"] = $"Houve um erro ao criar o quarto: {ex.Message}";
                }
            }

            // Caso o modelo não seja válido, refaz o SelectList para manter o valor selecionado
            ViewData["RoomTypeId"] = new SelectList(_context.RoomType, "RoomTypeId", "Type", roomModel.RoomTypeId);
            return View(roomModel); // Retorna à view com o modelo atual
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomModel = await _context.Room
                                          .Include(r => r.RoomType)  // Certifique-se de incluir RoomType, se necessário
                                          .FirstOrDefaultAsync(m => m.ID_ROOM == id);

            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);  // Retorna os dados do quarto para a view
        }

        // Método POST para salvar as alterações
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_ROOM, RoomType, RoomType.Type, RoomType.RoomCapacity, RoomType.HasView, RoomType.AcessibilityRoom")] RoomModel roomModel)
        {
            if (id != roomModel.ID_ROOM)
            {
                ViewBag.Entity = "Room";
                ViewBag.Controller = "Room";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingRoom = await _context.Room
                                                      .Include(r => r.RoomType)  // Certifique-se de incluir RoomType ao buscar o quarto
                                                      .FirstOrDefaultAsync(r => r.ID_ROOM == id);

                    if (existingRoom == null)
                    {
                        ViewBag.Entity = "Room";
                        ViewBag.Controller = "Room";
                        ViewBag.Action = "Index";
                        return View("EntityNoLongerExists");
                    }

                    // Atualiza os campos do quarto com os dados recebidos no formulário
                    existingRoom.RoomType.Type = roomModel.RoomType.Type;
                    existingRoom.RoomType.RoomCapacity = roomModel.RoomType.RoomCapacity;
                    existingRoom.RoomType.HasView = roomModel.RoomType.HasView;
                    existingRoom.RoomType.AcessibilityRoom = roomModel.RoomType.AcessibilityRoom;

                    _context.Update(existingRoom);  // Atualiza o quarto no banco
                    await _context.SaveChangesAsync();  // Salva as alterações no banco de dados
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomModelExists(roomModel.ID_ROOM))
                    {
                        ViewBag.Entity = "Room";
                        ViewBag.Controller = "Room";
                        ViewBag.Action = "Index";
                        return View("EntityNoLongerExists");
                    }
                    else
                    {
                        throw;
                    }
                }

                // Redireciona para a página de sucesso ou para a listagem de quartos
                ViewBag.Entity = "Room";
                ViewBag.Controller = "Room";
                ViewBag.Action = "Index";
                return View("Successfully");  // Pode ser substituído por RedirectToAction("Index") se preferir redirecionar.
            }

            // Se ModelState não for válido, retorna a view de edição com os erros
            return View(roomModel);
        }



        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(m => m.ID_ROOM == id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room); // Retorna para a página de confirmação
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Room deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Room not found!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RoomModelExists(int id)
        {
            return _context.Room.Any(e => e.RoomTypeId == id);
        }
    }
}
