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
<<<<<<<< HEAD:Controllers/ReservasController.cs
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
========
    public class PratosController : Controller
        {
        private readonly ApplicationDbContext _context;

        public PratosController(ApplicationDbContext context)
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
        {
            _context = context;
        }

<<<<<<<< HEAD:Controllers/ReservasController.cs
        // GET: Reservas
========
        // GET: Pratos
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prato.ToListAsync());
        }

<<<<<<<< HEAD:Controllers/ReservasController.cs
        // GET: Reservas/Details/5
========
        // GET: Pratos/Details/5
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .FirstOrDefaultAsync(m => m.IdPrato == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

<<<<<<<< HEAD:Controllers/ReservasController.cs
        // GET: Reservas/Create
========
        // GET: Pratos/Create
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
        public IActionResult Create()
        {
            return View();
        }

<<<<<<<< HEAD:Controllers/ReservasController.cs
        // POST: Reservas/Create
========
        // POST: Pratos/Create
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrato,PratoNome,Descricao")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prato);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            return View(prato);
                    }

<<<<<<<< HEAD:Controllers/ReservasController.cs
        // GET: Reservas/Edit/5
========
        // GET: Pratos/Edit/5
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
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

<<<<<<<< HEAD:Controllers/ReservasController.cs
        // POST: Reservas/Edit/5
========
        // POST: Pratos/Edit/5
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrato,PratoNome,Descricao")] Prato prato)
        {
            if (id != prato.IdPrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                    {
                    if (!PratoExists(prato.IdPrato))
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

<<<<<<<< HEAD:Controllers/ReservasController.cs
        // GET: Reservas/Delete/5
========
        // GET: Pratos/Delete/5
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .FirstOrDefaultAsync(m => m.IdPrato == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

<<<<<<<< HEAD:Controllers/ReservasController.cs
        // POST: Reservas/Delete/5
========
        // POST: Pratos/Delete/5
>>>>>>>> d383a10b65dded3aefe11ca251809fc3f7617840:Controllers/PratosController.cs
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
            return RedirectToAction(nameof(Index));
        }

        private bool PratoExists(int id)
        {
            return _context.Prato.Any(e => e.IdPrato == id);
        }
    }
}
