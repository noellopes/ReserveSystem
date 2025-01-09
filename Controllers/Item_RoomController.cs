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
    public class Item_RoomController : Controller
    {
        private readonly ReserveSystemContext _context;

        public Item_RoomController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Item_Room
        public async Task<IActionResult> Index()
        {
            return View(await _context.Item_Room.ToListAsync());
        }

        // GET: Item_Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_Room = await _context.Item_Room
                .FirstOrDefaultAsync(m => m.ItemRoomId == id);
            if (item_Room == null)
            {
                return NotFound();
            }

            return View(item_Room);
        }

        // GET: Item_Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item_Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemRoomId,RoomTypeId,ItemId,RoomQuantity")] Item_Room item_Room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item_Room);
                await _context.SaveChangesAsync();

                // Redireciona para a página de sucesso
                return RedirectToAction(nameof(RegistrationSuccess), new { id = item_Room.ItemRoomId });
            }
            return View(item_Room);
        }

        // Ação de sucesso após a criação do item
        public async Task<IActionResult> RegistrationSuccess(int id)
        {
            var item_Room = await _context.Item_Room.FindAsync(id);
            if (item_Room == null)
            {
                return NotFound();
            }

            return View(item_Room);
        }

        // GET: Item_Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_Room = await _context.Item_Room.FindAsync(id);
            if (item_Room == null)
            {
                return NotFound();
            }
            return View(item_Room);
        }

        // POST: Item_Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemRoomId,RoomTypeId,ItemId,RoomQuantity")] Item_Room item_Room)
        {
            if (id != item_Room.ItemRoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item_Room);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("EditSuccess", new { itemRoomId = item_Room.ItemRoomId });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Item_RoomExists(item_Room.ItemRoomId))
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
            return View(item_Room);
        }

        private bool Item_RoomExists(int itemRoomId)
        {
            throw new NotImplementedException();
        }

        // GET: ItemRoom/EditSuccess
        public async Task<IActionResult> EditSuccess(int itemRoomId)
        {
            var itemRoom = await _context.Item_Room
                .Include(ir => ir.roomType)
                .Include(ir => ir.items)
                .FirstOrDefaultAsync(ir => ir.ItemRoomId == itemRoomId);

            if (itemRoom == null)
            {
                return NotFound();
            }

            // Mensagem de sucesso
            ViewBag.Message = "Item Room edited successfully!";
            return View(itemRoom);
        }


        // GET: Item_Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_Room = await _context.Item_Room
                .FirstOrDefaultAsync(m => m.ItemRoomId == id);
            if (item_Room == null)
            {
                return NotFound();
            }

            return View(item_Room);
        }

        // POST: ItemRoom/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var itemRoom = await _context.Item_Room
        .Include(ir => ir.roomType)
        .Include(ir => ir.items)
        .FirstOrDefaultAsync(ir => ir.ItemRoomId == id);

    if (itemRoom != null)
    {
        _context.Item_Room.Remove(itemRoom);
        await _context.SaveChangesAsync();
    }

    // Redireciona para a página de confirmação de exclusão
    return RedirectToAction("DeleteSuccess", new 
    { 
        itemName = itemRoom?.items?.Name, 
    });
}

// GET: ItemRoom/DeleteSuccess
public IActionResult DeleteSuccess(string itemName, string roomType)
{
    ViewBag.ItemName = itemName;
    ViewBag.RoomType = roomType;
    return View();
}

    }
}
