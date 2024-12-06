﻿using System;
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
    public class PratosController : Controller
    {
        private readonly ReserveSystemContext _context;

        public PratosController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Pratos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prato.ToListAsync());
        }

        // GET: Pratos/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Pratos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PratoId,Nome,Descricao")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prato);
                await _context.SaveChangesAsync();
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PratoId,Nome,Descricao")] Prato prato)
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
            return RedirectToAction(nameof(Index));
        }

        private bool PratoExists(int id)
        {
            return _context.Prato.Any(e => e.PratoId == id);
        }
    }
}