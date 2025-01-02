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

            var roomModel = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            // Carregar os tipos de quarto para o dropdown
            ViewBag.RoomTypes = _context.RoomType.ToList();
            return View();
        }

        // Método POST - Salva o quarto no banco de dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomModel room)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verifica se o tipo de quarto existe
                    var roomType = await _context.RoomType.FirstOrDefaultAsync(rt => rt.RoomTypeId == room.RoomTypeId);
                    if (roomType == null)
                    {
                        ModelState.AddModelError("RoomTypeId", "O tipo de quarto selecionado não é válido.");
                        ViewBag.RoomTypes = _context.RoomType.ToList();
                        return View(room);
                    }

                    // Associa o tipo de quarto e salva no banco
                    room.RoomType = roomType;
                    _context.Room.Add(room);
                    await _context.SaveChangesAsync();

                    // Redireciona para a página de índice
                    TempData["SuccessMessage"] = "Quarto criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao tentar criar o quarto. Tente novamente.");
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }

            // Se a validação falhar, recarrega a página com mensagens de erro
            ViewBag.RoomTypes = _context.RoomType.ToList();
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomModel = await _context.Room.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }
            return View(roomModel);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomTypeId,RoomType,Capacity,NumberOfRooms,HasView,AdaptedRoom")] RoomModel roomModel)
        {
            if (id != roomModel.RoomTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomModelExists(roomModel.RoomTypeId))
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
