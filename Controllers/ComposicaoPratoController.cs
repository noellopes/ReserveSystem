using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class ComposicaoPratoController : Controller
    {

        private readonly ReserveSystemContext _context;

        public ComposicaoPratoController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ComposicaoPratoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComposicaoPratoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComposicaoPratoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComposicaoPratoController/Create
        [HttpPost]
        public async Task<IActionResult> Add(int pratoId, int ingredientId, double quantity)
        {
            var composicao = new ComposicaoPrato
            {
                PratoID = pratoId,
                IngredientID = ingredientId,
                IngredientQuantity = quantity
            };

            _context.ComposicaoPrato.Add(composicao);
            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", new { id = pratoId });
        }

        // GET: ComposicaoPratoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Obtem o prato e a sua composição
            var prato = await _context.Prato
                .Include(p => p.ComposicaoPratos)
                .ThenInclude(cp => cp.Ingredient)
                .FirstOrDefaultAsync(p => p.PratoId == id);

            if (prato == null)
            {
                return NotFound();
            }

            ViewBag.Ingredients = await _context.Ingredient.ToListAsync(); // Obtem a lista de ingredientes

            return View(prato); // Passa o prato e a composição para a view
        }

        // POST: ComposicaoPratoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComposicaoPratoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComposicaoPratoController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var composicao = await _context.ComposicaoPrato.FindAsync(id);

            if (composicao == null)
            {
                return NotFound();
            }

            _context.ComposicaoPrato.Remove(composicao);
            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", new { id = composicao.PratoID });
        }
    }
}
