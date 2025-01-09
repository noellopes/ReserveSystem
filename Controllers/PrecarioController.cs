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
    public class PrecarioController : Controller
    {
        private readonly ReserveSystemContext _context;

        public PrecarioController(ReserveSystemContext context)
        {
            _context = context;
        }

		// GET: Precario
		public async Task<IActionResult> Index(
			string searchString,
			string filterBy,
			string sortOrder,
			int page = 1,
			int pageSize = 13)
		{
			ViewBag.FilterBy = filterBy ?? "titulo";

			ViewBag.CurrentSort = sortOrder;
			ViewBag.TituloSortParm = sortOrder == "Titulo" ? "Titulo_desc" : "Titulo";
			ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


			var query = _context.PrecarioModel
							.Include(q => q.Excursao)
						   .AsQueryable();


			if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(filterBy))
			{
				switch (filterBy.ToLower())
				{
					case "titulo":
						query = query.Where(e => e.Excursao.Titulo.Contains(searchString));
						break;

					case "data":
						if (DateTime.TryParse(searchString, out DateTime searchDate))
						{
							query = query.Where(e => e.Data_Inicio.Date == searchDate.Date);
						}

						break;


				}
			}

			switch (sortOrder)
			{

				case "Date":
					query = query.OrderBy(e => e.Data_Inicio);
					break;
				case "date_desc":
					query = query.OrderByDescending(e => e.Data_Inicio);
					break;
				case "Titulo_desc":
					query = query.OrderByDescending(e => e.Excursao.Titulo);
					break;
				case "Titulo":
					query = query.OrderBy(e => e.Excursao.Titulo);
					break;


				default:
					query = query.OrderBy(e => e.Excursao.Titulo);
					break;

			}

			int totalItems = await query.CountAsync();

			var precario = await query
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			var viewModel = new PrecarioViewModel
			{
				Precarios = precario,
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					PageSize = pageSize,
					TotalItems = totalItems
				},
				SearchTitulo = filterBy == "titulo" ? searchString : string.Empty,
				SearchData = filterBy == "data" ? searchString : string.Empty
			};


			return View(viewModel);
		}


		
        // GET: Precario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precarioModel = await _context.PrecarioModel
				.Include(e => e.Excursao)
				.FirstOrDefaultAsync(m => m.PrecoId == id);
            if (precarioModel == null)
            {
                return NotFound();
            }

            return View(precarioModel);
        }

        // GET: Precario/Create
        public IActionResult Create()
        {
			ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "ExcursaoId", "Titulo");

			return View();
        }

        // POST: Precario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrecoId,Preco,Data_Inicio,ExcursaoId")] PrecarioModel precarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(precarioModel);
        }

        // GET: Precario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precarioModel = await _context.PrecarioModel.FindAsync(id);
            if (precarioModel == null)
            {
                return NotFound();
            }
            return View(precarioModel);
        }

        // POST: Precario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrecoId,Preco,Data_Inicio,ExcursaoId")] PrecarioModel precarioModel)
        {
            if (id != precarioModel.PrecoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecarioModelExists(precarioModel.PrecoId))
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
            return View(precarioModel);
        }

        // GET: Precario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precarioModel = await _context.PrecarioModel
                .FirstOrDefaultAsync(m => m.PrecoId == id);
            if (precarioModel == null)
            {
                return NotFound();
            }

            return View(precarioModel);
        }

        // POST: Precario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var precarioModel = await _context.PrecarioModel.FindAsync(id);
            if (precarioModel != null)
            {
                _context.PrecarioModel.Remove(precarioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecarioModelExists(int id)
        {
            return _context.PrecarioModel.Any(e => e.PrecoId == id);
        }
    }
}
