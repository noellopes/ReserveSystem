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
    public class ItemRoomsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ItemRoomsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ItemRooms
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.ItemRoom.Include(i => i.item).Include(i => i.roomBooking);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: ItemRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRoom = await _context.ItemRoom
                .Include(i => i.item)
                .Include(i => i.roomBooking)
                .FirstOrDefaultAsync(m => m.ItemRoomId == id);
            if (itemRoom == null)
            {
                return NotFound();
            }

            return View(itemRoom);
        }

        // GET: ItemRooms/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Set<Items>(), "ItemsId", "ItemsId");
            ViewData["RoomBookingId"] = new SelectList(_context.Set<RoomBooking>(), "RoomBookingId", "RoomBookingId");
            return View();
        }

        // POST: ItemRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemRoomId,AvailableQuantity,LastRestockedDate,RoomBookingId,ItemId")] ItemRoom itemRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Set<Items>(), "ItemsId", "ItemsId", itemRoom.ItemId);
            ViewData["RoomBookingId"] = new SelectList(_context.Set<RoomBooking>(), "RoomBookingId", "RoomBookingId", itemRoom.RoomBookingId);
            return View(itemRoom);
        }

        // GET: ItemRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRoom = await _context.ItemRoom.FindAsync(id);
            if (itemRoom == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Set<Items>(), "ItemsId", "ItemsId", itemRoom.ItemId);
            ViewData["RoomBookingId"] = new SelectList(_context.Set<RoomBooking>(), "RoomBookingId", "RoomBookingId", itemRoom.RoomBookingId);
            return View(itemRoom);
        }

        // POST: ItemRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemRoomId,AvailableQuantity,LastRestockedDate,RoomBookingId,ItemId")] ItemRoom itemRoom)
        {
            if (id != itemRoom.ItemRoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemRoomExists(itemRoom.ItemRoomId))
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
            ViewData["ItemId"] = new SelectList(_context.Set<Items>(), "ItemsId", "ItemsId", itemRoom.ItemId);
            ViewData["RoomBookingId"] = new SelectList(_context.Set<RoomBooking>(), "RoomBookingId", "RoomBookingId", itemRoom.RoomBookingId);
            return View(itemRoom);
        }

        // GET: ItemRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRoom = await _context.ItemRoom
                .Include(i => i.item)
                .Include(i => i.roomBooking)
                .FirstOrDefaultAsync(m => m.ItemRoomId == id);
            if (itemRoom == null)
            {
                return NotFound();
            }

            return View(itemRoom);
        }

        // POST: ItemRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemRoom = await _context.ItemRoom.FindAsync(id);
            if (itemRoom != null)
            {
                _context.ItemRoom.Remove(itemRoom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemRoomExists(int id)
        {
            return _context.ItemRoom.Any(e => e.ItemRoomId == id);
        }
    }
}
