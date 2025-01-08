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
    public class ExcursaoController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ExcursaoController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Excursao
        public async Task<IActionResult> Index()
        {
            var excursao = from e in _context.ExcursaoModel
						   .Include(e => e.Staff)
						   select e;
			return View(excursao);
        }

        // GET: Excursao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			var excursaoModel = await _context.ExcursaoModel
			   .Include(e => e.Staff)
			   .FirstOrDefaultAsync(m => m.ExcursaoId == id);
			if (excursaoModel == null)
            {
                return NotFound();
            }

            return View(excursaoModel);
        }

        // GET: Excursao/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.StaffModel, "StaffId", "Staff_Name");
			return View();
        }

        // POST: Excursao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ExcursaoId,Titulo,Descricao,Data_Inicio,Data_Fim,Preco,StaffId")] ExcursaoModel excursaoModel)
		{
			if (ModelState.IsValid)
			{
				_context.Add(excursaoModel);
				await _context.SaveChangesAsync();

				
				var precarioModel = new PrecarioModel
				{
					Preco = excursaoModel.Preco,
					Data_Inicio = DateTime.Now,
					ExcursaoId = excursaoModel.ExcursaoId
				};
				_context.PrecarioModel.Add(precarioModel);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}
			ViewData["StaffId"] = new SelectList(_context.StaffModel, "StaffId", "Staff_Name");
			return View(excursaoModel);
		}

		// GET: Excursao/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursaoModel = await _context.ExcursaoModel.FindAsync(id);
            if (excursaoModel == null)
            {
                return NotFound();
            }
			ViewData["StaffId"] = new SelectList(_context.StaffModel, "StaffId", "Staff_Name");

			return View(excursaoModel);
        }

        // POST: Excursao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ExcursaoId,Titulo,Descricao,Data_Inicio,Data_Fim,Preco,StaffId")] ExcursaoModel excursaoModel)
		{
			if (id != excursaoModel.ExcursaoId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var existingExcursao = await _context.ExcursaoModel.AsNoTracking().FirstOrDefaultAsync(e => e.ExcursaoId == id);
					if (existingExcursao == null)
					{
						return NotFound();
					}

					// Verificando se o preço mudou
					bool precoMudou = existingExcursao.Preco != excursaoModel.Preco;

					_context.Update(excursaoModel);
					await _context.SaveChangesAsync();

					
					if (precoMudou)
					{
						var precarioModel = new PrecarioModel
						{
							Preco = excursaoModel.Preco,
							Data_Inicio = DateTime.Now, 
							ExcursaoId = excursaoModel.ExcursaoId
						};
						_context.PrecarioModel.Add(precarioModel);
						await _context.SaveChangesAsync();
					}
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ExcursaoModelExists(excursaoModel.ExcursaoId))
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
			ViewData["StaffId"] = new SelectList(_context.StaffModel, "StaffId", "Staff_Name");
			return View(excursaoModel);
		}

		// GET: Excursao/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			var excursaoModel = await _context.ExcursaoModel
			   .Include(e => e.Staff)
			   .FirstOrDefaultAsync(m => m.ExcursaoId == id);
			if (excursaoModel == null)
            {
                return NotFound();
            }

            return View(excursaoModel);
        }

        // POST: Excursao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            

            var excursaoModel = await _context.ExcursaoModel.FindAsync(id);
            if (excursaoModel != null)
            {
                _context.ExcursaoModel.Remove(excursaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcursaoModelExists(int id)
        {
            return _context.ExcursaoModel.Any(e => e.ExcursaoId == id);
        }
    }
}