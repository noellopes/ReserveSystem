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
    public class IngredientsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public IngredientsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index(int page = 1)
        {
            int itemsPerPage = 15; // Número de itens por página
            var totalItems = await _context.Ingredient.CountAsync(); // Total de ingredientes

            var ingredients = await _context.Ingredient
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync(); // Ingredients para a página atual

            var pagingInfo = new PagingInfo
            {
                TotalItems = totalItems,
                ItemsPerPage = itemsPerPage,
                CurrentPage = page
            };

            // ViewModel para passar os ingredients e a paginação
            var model = new IngredientListViewModel
            {
                Ingredient = ingredients,
                PagingInfo = pagingInfo
            };

            return View(model);
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.IngredientID == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientID,Name,UnityMeasure,StockMin,QuantityAvailable")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                // Define a data atual para LastModificationDate
                ingredient.LastModificationDate = DateTime.Now;

                _context.Add(ingredient);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Prato criado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientID,Name,UnityMeasure,StockMin,QuantityAvailable,LastModificationDate")] Ingredient ingredient)
        {
            if (id != ingredient.IngredientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ingredient.LastModificationDate = DateTime.Now; // Atualizar data da modificação
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Prato atualizado com sucesso!";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IngredientID))
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
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.IngredientID == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredient.Remove(ingredient);
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Prato excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.IngredientID == id);
        }
    }
}
