using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PagedList;
using ReserveSystem.Data;
using ReserveSystem.Models;
using PagedList;
using ReserveSystem.Migrations;

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
        public async Task<IActionResult> Index(
            string searchString,
            string filterBy,
            string sortOrder,
            int page = 1,
            int pageSize = 9)
        {
            ViewBag.FilterBy = filterBy ?? "titulo";

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TituloSortParm = sortOrder == "Titulo" ? "Titulo_desc" : "Titulo";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var query = _context.ExcursaoFavoritaModel
               .Include(r => r.Cliente)
               .Include(r => r.Excursao)
               .AsQueryable();

            /*if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }*/

            //FILTRO

            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(filterBy))
            {
                switch (filterBy.ToLower())
                {

                    case "titulo":
                        query = query.Where(f => f.Excursao.Titulo.Contains(searchString));
                        break;

                    case "data":

                        if (!string.IsNullOrEmpty(searchString) && int.TryParse(searchString, out int searchNumber))
                        {

                            query = query.Where(f => f.Excursao.Data_Fim.Day == searchNumber ||
                                                       f.Excursao.Data_Fim.Month == searchNumber ||
                                                       f.Excursao.Data_Fim.Year.ToString().Contains(searchString));
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Por favor, insira um valor válido.";
                        }


                        break;
                    

                }

            }

            //SORTING

            switch (sortOrder)
            {
                case "Titulo_desc":
                    query = query.OrderByDescending(f => f.Excursao.Titulo);
                    break;
                case "Date":
                    query = query.OrderBy(f => f.Excursao.Data_Fim);
                    break;
                case "Date_desc":
                    query = query.OrderByDescending(f => f.Excursao.Data_Fim);
                    break;
                default:
                    query = query.OrderBy(f => f.Excursao.Titulo);
                    break;
            }

            int totalItems = await query.CountAsync();

            var favoritas = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            var viewModel = new ExcursaoFavoritaViewModel
            {
                ExcursaoFavoritas = favoritas,
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

            //return View(await favoritas.ToListAsync());
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome");
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Titulo");

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
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome", excursaoFavoritaModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Titulo", excursaoFavoritaModel.ExcursaoId);
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome", excursaoFavoritaModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Titulo", excursaoFavoritaModel.ExcursaoId);
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome", excursaoFavoritaModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Titulo", excursaoFavoritaModel.ExcursaoId);
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

        // POST: ExcursaoFavorita/Delete/BulkDelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkDelete(List<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                TempData["ErrorMessage"] = "No excursions were selected for deletion.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                // Fetch selected excursions and remove them
                var excursaoFavoritas = _context.ExcursaoFavoritaModel.Where(e => selectedIds.Contains(e.Id));

                if (excursaoFavoritas.Any())
                {
                    _context.ExcursaoFavoritaModel.RemoveRange(excursaoFavoritas);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Selected excursions were successfully deleted.";
                }
                else
                {
                    TempData["ErrorMessage"] = "No valid excursions found for deletion.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting excursions: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}