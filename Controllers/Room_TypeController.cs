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
    public class Room_TypeController : Controller
    {
        private readonly ReserveSystemContext _context;

        public Room_TypeController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Room_Type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room_Type.ToListAsync());
        }

        // GET: Room_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Type = await _context.Room_Type
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (room_Type == null)
            {
                return NotFound();
            }

            return View(room_Type);
        }

        // GET: Room_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomTypeId,HasView,Type,Capacity,RoomCapacity,AcessibilityRoom")] Room_Type roomType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomType);
                await _context.SaveChangesAsync();
                // Redireciona para a página de confirmação após o registro
                return RedirectToAction("RegisterComplete", new { id = roomType.RoomTypeId });
            }
            return View(roomType);
        }


        // GET: RoomTypes/RegisterComplete/5
        public async Task<IActionResult> RegisterComplete(int id)
        {
            var roomType = await _context.Room_Type.FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // GET: Room_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Type = await _context.Room_Type.FindAsync(id);
            if (room_Type == null)
            {
                return NotFound();
            }
            return View(room_Type);
        }

        // POST: Room_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomTypeId,HasView,Type,Capacity,RoomCapacity,AcessibilityRoom")] Room_Type room_Type)
        {
            if (id != room_Type.RoomTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room_Type);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("EditSuccess", new { roomTypeId = room_Type.RoomTypeId });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Room_TypeExists(room_Type.RoomTypeId))
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
            return View(room_Type);
        }

        // GET: RoomTypes/EditSuccess
        public async Task<IActionResult> EditSuccess(int roomTypeId)
        {
            var roomType = await _context.Room_Type
                .Include(r => r.rooms)
                .FirstOrDefaultAsync(r => r.RoomTypeId == roomTypeId);

            if (roomType == null)
            {
                return NotFound();
            }

            // Mensagem de sucesso
            ViewBag.Message = "Room type edited successfully!";
            return View(roomType);
        }


        // GET: Room_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room_Type = await _context.Room_Type
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (room_Type == null)
            {
                return NotFound();
            }

            return View(room_Type);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomType = await _context.Room_Type.FindAsync(id);
            if (roomType != null)
            {
                _context.Room_Type.Remove(roomType);
                await _context.SaveChangesAsync();
            }

            // Redireciona para a página de confirmação de exclusão
            return RedirectToAction("DeleteSuccess", new { roomTypeId = roomType?.RoomTypeId, roomTypeDescription = roomType?.Type });
        }

        // GET: RoomTypes/DeleteSuccess
        public IActionResult DeleteSuccess(int? roomTypeId, string roomTypeDescription)
        {
            ViewBag.RoomTypeId = roomTypeId;
            ViewBag.RoomTypeDescription = roomTypeDescription;
            return View();
        }

        private bool RoomTypeExists(int id)
        {
            return _context.Room_Type.Any(e => e.RoomTypeId == id);
        }

    }
}
