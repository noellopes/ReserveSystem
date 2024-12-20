using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Controllers
{
    public class BuffetsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public BuffetsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Buffets
        public async Task<IActionResult> Index(int page = 1)
        {
            int itemsPerPage = 15; // Número de itens por página
            var totalItems = await _context.Buffet.CountAsync(); // Total de buffets

            var buffets = await _context.Buffet
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync(); // Buffets para a página atual

            var pagingInfo = new PagingInfo
            {
                TotalItems = totalItems,
                ItemsPerPage = itemsPerPage,
                CurrentPage = page
            };

            // ViewModel para passar os buffets e a paginação
            var model = new BuffetListViewModel
            {
                Buffets = buffets,
                PagingInfo = pagingInfo
            };

            return View(model);
        }

        // GET: Buffets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffet = await _context.Buffet
                .FirstOrDefaultAsync(m => m.BuffetId == id);
            if (buffet == null)
            {
                return NotFound();
            }

            return View(buffet);
        }

        // GET: Buffets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buffets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuffetId,Nome,Descricao,Data")] Buffet buffet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buffet);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Buffet criado com sucesso!"; // Mensagem de sucesso

                return RedirectToAction(nameof(Index));
            }
            return View(buffet);
        }

        // GET: Buffets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffet = await _context.Buffet.FindAsync(id);
            if (buffet == null)
            {
                return NotFound();
            }
            return View(buffet);
        }

        // POST: Buffets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuffetId,Nome,Descricao,Data")] Buffet buffet)
        {
            if (id != buffet.BuffetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buffet);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Buffet atualizado com sucesso!"; // Mensagem de sucesso
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuffetExists(buffet.BuffetId))
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
            return View(buffet);
        }

        // GET: Buffets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffet = await _context.Buffet
                .FirstOrDefaultAsync(m => m.BuffetId == id);
            if (buffet == null)
            {
                return NotFound();
            }

            return View(buffet);
        }

        // POST: Buffets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buffet = await _context.Buffet.FindAsync(id);
            if (buffet != null)
            {
                _context.Buffet.Remove(buffet);
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Buffet excluído com sucesso!"; // Mensagem de sucesso

            return RedirectToAction(nameof(Index));
        }

        private bool BuffetExists(int id)
        {
            return _context.Buffet.Any(e => e.BuffetId == id);
        }
    }
}
