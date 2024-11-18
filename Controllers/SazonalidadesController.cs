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
    public class SazonalidadesController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public SazonalidadesController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: Sazonalidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sazonalidade.ToListAsync());
        }

        // GET: Sazonalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sazonalidade = await _context.Sazonalidade
                .FirstOrDefaultAsync(m => m.Id_saz == id);
            if (sazonalidade == null)
            {
                return NotFound();
            }

            return View(sazonalidade);
        }

        // GET: Sazonalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sazonalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_saz,NameSeason,DateBegin,DateEnd,InUse")] Sazonalidade sazonalidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sazonalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sazonalidade);
        }

        // GET: Sazonalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sazonalidade = await _context.Sazonalidade.FindAsync(id);
            if (sazonalidade == null)
            {
                return NotFound();
            }
            return View(sazonalidade);
        }

        // POST: Sazonalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_saz,NameSeason,DateBegin,DateEnd,InUse")] Sazonalidade sazonalidade)
        {
            if (id != sazonalidade.Id_saz)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sazonalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SazonalidadeExists(sazonalidade.Id_saz))
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
            return View(sazonalidade);
        }

        // GET: Sazonalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sazonalidade = await _context.Sazonalidade
                .FirstOrDefaultAsync(m => m.Id_saz == id);
            if (sazonalidade == null)
            {
                return NotFound();
            }

            return View(sazonalidade);
        }

        // POST: Sazonalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sazonalidade = await _context.Sazonalidade.FindAsync(id);
            if (sazonalidade != null)
            {
                _context.Sazonalidade.Remove(sazonalidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SazonalidadeExists(int id)
        {
            return _context.Sazonalidade.Any(e => e.Id_saz == id);
        }
    }
}
