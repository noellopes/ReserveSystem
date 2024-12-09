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
    public class ReservaExcursaoController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ReservaExcursaoController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ReservaExcursao
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.ReservaExcursaoModel.Include(r => r.Cliente).Include(r => r.Excursao);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: ReservaExcursao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaExcursaoModel = await _context.ReservaExcursaoModel
                .Include(r => r.Cliente)
                .Include(r => r.Excursao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaExcursaoModel == null)
            {
                return NotFound();
            }

            return View(reservaExcursaoModel);
        }

        // GET: ReservaExcursao/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome");
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao");
            return View();
        }

        // POST: ReservaExcursao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ExcursaoId,DataReserva,NumPessoas,ValorTotal")] ReservaExcursaoModel reservaExcursaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaExcursaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Email", reservaExcursaoModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", reservaExcursaoModel.ExcursaoId);
            return View(reservaExcursaoModel);
        }

        // GET: ReservaExcursao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaExcursaoModel = await _context.ReservaExcursaoModel.FindAsync(id);
            if (reservaExcursaoModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Email", reservaExcursaoModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", reservaExcursaoModel.ExcursaoId);
            return View(reservaExcursaoModel);
        }

        // POST: ReservaExcursao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ExcursaoId,DataReserva,NumPessoas,ValorTotal")] ReservaExcursaoModel reservaExcursaoModel)
        {
            if (id != reservaExcursaoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaExcursaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExcursaoModelExists(reservaExcursaoModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Email", reservaExcursaoModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", reservaExcursaoModel.ExcursaoId);
            return View(reservaExcursaoModel);
        }

        // GET: ReservaExcursao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaExcursaoModel = await _context.ReservaExcursaoModel
                .Include(r => r.Cliente)
                .Include(r => r.Excursao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaExcursaoModel == null)
            {
                return NotFound();
            }

            return View(reservaExcursaoModel);
        }

        // POST: ReservaExcursao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaExcursaoModel = await _context.ReservaExcursaoModel.FindAsync(id);
            if (reservaExcursaoModel != null)
            {
                _context.ReservaExcursaoModel.Remove(reservaExcursaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExcursaoModelExists(int id)
        {
            return _context.ReservaExcursaoModel.Any(e => e.Id == id);
        }
    }
}
