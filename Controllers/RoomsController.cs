using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Room/RegisterComplete/5
        public async Task<IActionResult> RegisterComplete(int id)
        {
            var room = await _context.Room.FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,RoomTypeId,RoomNumber,Floor,Capacity,HasView,IsAvailable")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                // Redireciona para a página de confirmação após o registro
                return RedirectToAction("RegisterComplete", new { id = room.RoomId });
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,RoomTypeId")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("EditSuccess", new { roomId = room.RoomId });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
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
            return View(room);
        }

        // GET: Rooms/EditSuccess
        public async Task<IActionResult> EditSuccess(int roomId)
        {
            var room = await _context.Room
                .Include(r => r.roomType)
                .FirstOrDefaultAsync(r => r.RoomId == roomId);

            if (room == null)
            {
                return NotFound();
            }

            // Mensagem de sucesso
            ViewBag.Message = "Room edited successfully!";
            return View(room);
        }


        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
                await _context.SaveChangesAsync();
            }

            // Redireciona para a página de confirmação de exclusão
            return RedirectToAction("DeleteSuccess", new { roomId = room?.RoomId, roomType = room?.roomType?.Type });
        }

        // GET: Rooms/DeleteSuccess
        public IActionResult DeleteSuccess(int? roomId, string roomType)
        {
            ViewBag.RoomId = roomId;
            ViewBag.RoomType = roomType;
            return View();
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomId == id);
        }

    }
}
