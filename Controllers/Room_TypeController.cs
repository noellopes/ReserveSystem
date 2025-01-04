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

        // POST: Room_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomTypeId,HasView,Type,Capacity,RoomCapacity,AcessibilityRoom")] Room_Type room_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room_Type);
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

        // POST: Room_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room_Type = await _context.Room_Type.FindAsync(id);
            if (room_Type != null)
            {
                _context.Room_Type.Remove(room_Type);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Room_TypeExists(int id)
        {
            return _context.Room_Type.Any(e => e.RoomTypeId == id);
        }
    }
}
