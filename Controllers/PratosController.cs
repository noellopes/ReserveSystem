using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Controllers
{
    public class PratosController : Controller
    {
        private readonly ReserveSystemContext _context;

        public PratosController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Pratos
        public async Task<IActionResult> Index(int page = 1)
        {
            int itemsPerPage = 15; // Número de itens por página
            var totalItems = await _context.Prato.CountAsync(); // Total de pratos

            var pratos = await _context.Prato
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync(); // Pratos para a página atual

            var pagingInfo = new PagingInfo
            {
                TotalItems = totalItems,
                ItemsPerPage = itemsPerPage,
                CurrentPage = page
            };

            // ViewModel para passar os pratos e a paginação
            var model = new PratoListViewModel
            {
                Pratos = pratos,
                PagingInfo = pagingInfo
            };

            return View(model);
        }

        // GET: Pratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .Include(p => p.ComposicaoPratos)
                .ThenInclude(cp => cp.Ingredient)
                .FirstOrDefaultAsync(m => m.PratoId == id);

            if (prato == null)
            {
                return NotFound();
            }

            if (prato.ComposicaoPratos != null && prato.ComposicaoPratos.Any())
            {
                foreach (var composicao in prato.ComposicaoPratos)
                {
                    Console.WriteLine($"Ingrediente: {composicao.Ingredient.Name}, Quantidade: {composicao.IngredientQuantity}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum ingrediente encontrado para o prato.");
            }

            return View(prato);
        }

        // GET: Pratos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pratos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PratoId,Nome,Descricao,Preco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prato);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Prato criado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            return View(prato);
        }

        // GET: Pratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato.FindAsync(id);
            if (prato == null)
            {
                return NotFound();
            }
            return View(prato);
        }

        // POST: Pratos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PratoId,Nome,Descricao,Preco")] Prato prato)
        {
            if (id != prato.PratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prato);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Prato atualizado com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PratoExists(prato.PratoId))
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
            return View(prato);
        }

        // GET: Pratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .FirstOrDefaultAsync(m => m.PratoId == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // POST: Pratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prato = await _context.Prato.FindAsync(id);
            if (prato != null)
            {
                _context.Prato.Remove(prato);
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Prato excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        private bool PratoExists(int id)
        {
            return _context.Prato.Any(e => e.PratoId == id);
        }
    }
}
