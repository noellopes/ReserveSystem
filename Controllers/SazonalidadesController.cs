 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using ReserveSystem.Data;
using ReserveSystem.Models;
using static System.Reflection.Metadata.BlobBuilder;


namespace ReserveSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SazonalidadesController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public SazonalidadesController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Sazonalidades
        public async Task<IActionResult> ViewSeasonList(int page = 1, string searchName = "", DateOnly? searchDate = null)
        {
            var seasons = from s in _context.Sazonalidade select s;

            if (!string.IsNullOrEmpty(searchName))
            {
                seasons = seasons.Where(s => s.NameSeason.Contains(searchName));
            }

            if (searchDate != null)
            {
                var searchDateTime = searchDate.Value.ToDateTime(TimeOnly.MinValue); 
                seasons = seasons.Where(s => (s.DateBegin.Date == searchDateTime.Date || s.DateEnd.Date == searchDateTime.Date || 
                                        (s.DateBegin < searchDateTime && s.DateEnd > searchDateTime)) && s.InUse);
            }

            var model = new SeasonalityViewModel();

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = await seasons.CountAsync(),
            };

            model.Sazonalidades = await seasons
                .OrderBy(s => s.NameSeason)
                .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.PageSize)
                .Take(model.PagingInfo.PageSize)
                .ToListAsync();

            model.SearchName = searchName;
            model.SearchDate = searchDate;
             
            return View(model);
        }

        // GET: Sazonalidades/Details/5
        public async Task<IActionResult> Details(int? id, bool savednow = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sazonalidade = await _context.Sazonalidade
                .FirstOrDefaultAsync(m => m.Id_saz == id);
            if (sazonalidade == null)
            {

                ViewBag.Entity = "Seasonality";
                ViewBag.Controller = "Sazonalidades";
                ViewBag.Action = "ViewSeasonList";
                return View("EntityNoLongerExists");
            }

            ViewBag.Saved = savednow;
            return View(sazonalidade);
        }

        // GET: Sazonalidades/ConfigSeason
        public IActionResult ConfigSeason(string? name = null)
        {
            if(name != null)
            {
                Sazonalidade sazonalidade = new Sazonalidade
                {
                    NameSeason = name
                };

                ViewBag.PreviouslyDeleted = true;
                return View(sazonalidade);
            }

            return View();
        }

        // POST: Sazonalidades/ConfigSeason
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfigSeason([Bind("Id_saz,NameSeason,DateBegin,DateEnd,InUse,SeasonFee")] Sazonalidade sazonalidade)
        {

            bool datesOverlap = await _context.Sazonalidade.AnyAsync(e => e.Id_saz != sazonalidade.Id_saz && // Ignorar a própria sazonalidade (no caso de edição)
                                                                          e.InUse && // Apenas sazonalidades ativas
            ((sazonalidade.DateBegin >= e.DateBegin && sazonalidade.DateBegin <= e.DateEnd) || // Data de início no intervalo
            (sazonalidade.DateEnd >= e.DateBegin && sazonalidade.DateEnd <= e.DateEnd) ||   // Data de término no intervalo
            (sazonalidade.DateBegin <= e.DateBegin && sazonalidade.DateEnd >= e.DateEnd))); // Nova sazonalidade cobre todo o intervalo existente

            if (datesOverlap)
            {
                ModelState.AddModelError("DateBegin", "The dates of the new seasonality overlaps with an existing active one.");
            }


            bool seasonExists = await _context.Sazonalidade.AnyAsync(e => e.NameSeason == sazonalidade.NameSeason && sazonalidade.InUse == true);
            if (seasonExists) ModelState.AddModelError("NameSeason", "There already exists a seasonality with this name. Please alter the name.");

            if ((sazonalidade.DateEnd - sazonalidade.DateBegin).TotalDays > 124) ModelState.AddModelError("DateEnd", "The maximum time of a seasonality is roughly 4 months (124 days).");

            if (ModelState.IsValid)
            {
                _context.Add(sazonalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = sazonalidade.Id_saz, savednow = true });
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
                ViewBag.Entity = "Seasonality";
                ViewBag.Controller = "Sazonalidades";
                ViewBag.Action = "ViewSeasonList";
                return View("EntityNoLongerExists");
            }
            return View(sazonalidade);
        }

        // POST: Sazonalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_saz,NameSeason,DateBegin,DateEnd,InUse,SeasonFee")] Sazonalidade sazonalidade)
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
                        return RedirectToAction(nameof(ConfigSeason), new { name = sazonalidade.NameSeason, datestart = sazonalidade.DateBegin, dateend = sazonalidade.DateEnd, used = sazonalidade.InUse, fee = sazonalidade.SeasonFee });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = sazonalidade.Id_saz, savednow = true});
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
                ViewBag.Entity = "Seasonality";
                ViewBag.Controller = "Sazonalidades";
                ViewBag.Action = "ViewSeasonList";

                return View("SuccessfullyDeleted");
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

                sazonalidade.InUse = false;

                //_context.Sazonalidade.Remove(sazonalidade);
                _context.Update(sazonalidade);
                await _context.SaveChangesAsync();
            }
            ViewBag.Entity = "Seasonality";
            ViewBag.Controller = "Sazonalidades";
            ViewBag.Action = "ViewSeasonList";

            return View("SuccessfullyDeleted");
        }

        private bool SazonalidadeExists(int id)
        {
            return _context.Sazonalidade.Any(e => e.Id_saz == id);
        }
    }
}
