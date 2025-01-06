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
            // Carregar os tipos de quarto disponíveis para o dropdown
            ViewBag.RoomTypes = _context.RoomType.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomModel room)
        {
            if (ModelState.IsValid)
            {
                var roomType = _context.RoomType.FirstOrDefault(rt => rt.RoomTypeId == room.RoomTypeId);

                _context.Room.Add(room); // Adiciona o novo quarto no banco de dados
                _context.SaveChanges(); // Salva as mudanças no banco de dados

                // Redireciona para a página de listagem de quartos após a criação
                TempData["SuccessMessage"] = "Room created successfully!";
                return RedirectToAction("Index");
            }

            // Se o modelo for inválido, recarrega a página com os tipos de quarto disponíveis
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
