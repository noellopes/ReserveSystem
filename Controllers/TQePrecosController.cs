using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TQePrecosController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public TQePrecosController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: TQePrecos
        public async Task<IActionResult> Index()
        {
            var roomTypes = await _context.TQePreco.ToListAsync();
            return View(roomTypes);
        }


        // GET: TQePrecos/Details/5
        public async Task<IActionResult> Details(int? id, bool SavedN = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tQePreco = await _context.TQePreco
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (tQePreco == null)
            {
                ViewBag.Entity = "Room Price";
                ViewBag.Controller = "TQePrecos";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
                //return NotFound();
            }
            ViewBag.Saved = SavedN;
            return View(tQePreco);
        }

        // GET: TQePrecos/Create
        public IActionResult Create(string? name = null)
        {
            if (name!=null)
            {
                TQePreco tQePreco = new TQePreco
                {
                    type = name
                };
                ViewBag.PrevioslyDeleted = true;
                return View(tQePreco);
            }
            return View();
        }

        // POST: TQePrecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomTypeId,type,capacity,RoomQuantity,AcessibilityRoom,View,BasePrice,AdicionalBeds,InUse")] TQePreco tQePreco)
        {
            //validação quando ainda se inseria um roomtype agora só se altera o preço base do já existente
            bool RtypeExists = await _context.TQePreco.AnyAsync(e  => e.type == tQePreco.type);
            if (RtypeExists)
            {
                ModelState.AddModelError("type", "A room type with this name already exists");
            }
            if (ModelState.IsValid)
            {
                _context.Add(tQePreco);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
               return RedirectToAction(nameof(Details), new { id = tQePreco.RoomTypeId, SavedN = true });
            }
            return View(tQePreco);
        }

        // GET: TQePrecos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tQePreco = await _context.TQePreco.FindAsync(id);
            if (tQePreco == null)
            {
                ViewBag.Entity = "Room Price";
                ViewBag.Controller = "TQePrecos";
                ViewBag.Action = "Details";
                ViewBag.Id = tQePreco.RoomTypeId;
                return View("EntityNoLongerExists");
                //return NotFound();
            }
            return View(tQePreco);
        }

        // POST: TQePrecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomTypeId,type,capacity,RoomQuantity,AcessibilityRoom,View,BasePrice,AdicionalBeds,InUse")] TQePreco tQePreco)
        {
            if (id != tQePreco.RoomTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Carregar o objeto existente do banco de dados
                    var existingRoomType = await _context.TQePreco.FindAsync(id);

                    if (existingRoomType == null)
                    {
                        return NotFound();
                    }

                    // Atualizar todos os campos conforme necessário
                    existingRoomType.type = tQePreco.type;
                    existingRoomType.capacity = tQePreco.capacity;
                    existingRoomType.RoomQuantity = tQePreco.RoomQuantity;
                    existingRoomType.AcessibilityRoom = tQePreco.AcessibilityRoom;
                    existingRoomType.View = tQePreco.View;
                    existingRoomType.BasePrice = tQePreco.BasePrice;
                    existingRoomType.AdicionalBeds = tQePreco.AdicionalBeds;

                    // Definir o valor de InUse com base no valor de BasePrice
                    existingRoomType.InUse = tQePreco.BasePrice > 0;

                    _context.Update(existingRoomType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TQePrecoExists(tQePreco.RoomTypeId))
                    {
                        //return NotFound();
                        return RedirectToAction(nameof(Create), new { name = tQePreco.type, cap = tQePreco.capacity, quant = tQePreco.RoomQuantity, accesR = tQePreco.AcessibilityRoom, view = tQePreco.View, Bprice = tQePreco.BasePrice, bed = tQePreco.AdicionalBeds, alreadyUsed = tQePreco.InUse });
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Details), new { id = tQePreco.RoomTypeId, SavedN = true });
                ViewBag.Entity = "Room Price";
                ViewBag.Controller = "TQePrecos";
                ViewBag.Action = "Details";
                ViewBag.Id = tQePreco.RoomTypeId;
                return View("UpdatePrice");

            }
            return View(tQePreco);
        }


        // GET: TQePrecos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tQePreco = await _context.TQePreco
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (tQePreco == null)
            {
                //return NotFound();
                ViewBag.Entity = "Room Price";
                ViewBag.Controller = "TQePrecos";
                ViewBag.Action = "Index";
                return View("DeletePrice");
            }

            return View(tQePreco);
        }

        // POST: TQePrecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tQePreco = await _context.TQePreco.FindAsync(id);
            if (tQePreco != null)
            {
                tQePreco.BasePrice = 0;
                tQePreco.InUse = false;
                //_context.TQePreco.Remove(tQePreco);
                _context.Update(tQePreco);
                await _context.SaveChangesAsync();
            }

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            ViewBag.Entity = "Room Price";
            ViewBag.Controller = "TQePrecos";
            ViewBag.Action = "Index";
            return View("DeletePrice");
        }

        private bool TQePrecoExists(int id)
        {
            return _context.TQePreco.Any(e => e.RoomTypeId == id);
        }
    }
}
