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
    public class ExcursaoFavoritaController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ExcursaoFavoritaController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ExcursaoFavorita
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.ExcursaoFavoritaModel.Include(e => e.Cliente).Include(e => e.Excursao);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: ExcursaoFavorita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursaoFavoritaModel = await _context.ExcursaoFavoritaModel
                .Include(e => e.Cliente)
                .Include(e => e.Excursao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excursaoFavoritaModel == null)
            {
                return NotFound();
            }

            return View(excursaoFavoritaModel);
        }

        // GET: ExcursaoFavorita/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Email");
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao");
            return View();
        }

        // POST: ExcursaoFavorita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ExcursaoId,Comentario")] ExcursaoFavoritaModel excursaoFavoritaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excursaoFavoritaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Email", excursaoFavoritaModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", excursaoFavoritaModel.ExcursaoId);
            return View(excursaoFavoritaModel);
        }

        // GET: ExcursaoFavorita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursaoFavoritaModel = await _context.ExcursaoFavoritaModel.FindAsync(id);
            if (excursaoFavoritaModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Email", excursaoFavoritaModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", excursaoFavoritaModel.ExcursaoId);
            return View(excursaoFavoritaModel);
        }

        // POST: ExcursaoFavorita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ExcursaoId,Comentario")] ExcursaoFavoritaModel excursaoFavoritaModel)
        {
            if (id != excursaoFavoritaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excursaoFavoritaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcursaoFavoritaModelExists(excursaoFavoritaModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Email", excursaoFavoritaModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", excursaoFavoritaModel.ExcursaoId);
            return View(excursaoFavoritaModel);
        }

        // GET: ExcursaoFavorita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursaoFavoritaModel = await _context.ExcursaoFavoritaModel
                .Include(e => e.Cliente)
                .Include(e => e.Excursao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excursaoFavoritaModel == null)
            {
                return NotFound();
            }

            return View(excursaoFavoritaModel);
        }

        // POST: ExcursaoFavorita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excursaoFavoritaModel = await _context.ExcursaoFavoritaModel.FindAsync(id);
            if (excursaoFavoritaModel != null)
            {
                _context.ExcursaoFavoritaModel.Remove(excursaoFavoritaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcursaoFavoritaModelExists(int id)
        {
            return _context.ExcursaoFavoritaModel.Any(e => e.Id == id);
        }
    }
}
