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
    public class RoomTypesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomTypesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomTypes
        public async Task<IActionResult> Index(string searchQuery)
        {
            // Verifica se há um valor no parâmetro de busca
            var roomTypes = from rt in _context.RoomType
                            select rt;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Aplica o filtro por Tipo ou Capacidade
                roomTypes = roomTypes.Where(rt => rt.Type.Contains(searchQuery) || rt.RoomCapacity.ToString().Contains(searchQuery));
            }

            // Passa o valor de busca para a ViewData para manter o valor no campo de busca
            ViewData["SearchQuery"] = searchQuery;

            return View(await roomTypes.ToListAsync());
        }

        // GET: RoomTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // GET: RoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                // Adiciona o RoomType ao banco
                _context.RoomType.Add(roomType);
                await _context.SaveChangesAsync();

                // Associa um quarto automaticamente ao RoomTypeId recém-criado
                var room = new RoomModel
                {
                    RoomTypeId = roomType.RoomTypeId
                };

                _context.Room.Add(room);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Tipo de quarto criado com sucesso, e um quarto foi associado automaticamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(roomType);
        }

        // GET: RoomTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HasView,Type,RoomCapacity,AcessibilityRoom")] RoomType roomType)
        {
            if (id != roomType.RoomTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomTypeExists(roomType.RoomTypeId))
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
            return View(roomType);
        }

        // GET: RoomTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType != null)
            {
                _context.RoomType.Remove(roomType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomTypeExists(int id)
        {
            return _context.RoomType.Any(e => e.RoomTypeId == id);
        }
    }
}
