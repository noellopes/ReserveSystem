using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class DaysOffAndVacationsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public DaysOffAndVacationsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: DaysOffAndVacations
        public async Task<IActionResult> Index(string startDate, string endDate, int page = 1, int pageSize = 10)
        {
            DateTime? start = null;
            DateTime? end = null;

            if (DateTime.TryParse(startDate, out var parsedStart))
            {
                start = parsedStart.Date;
            }

            if (DateTime.TryParse(endDate, out var parsedEnd))
            {
                end = parsedEnd.Date;
            }

            var query = _context.DaysOffAndVacations.AsQueryable();

            if (start.HasValue)
            {
                query = query.Where(d => d.StartDate.Date >= start.Value);
            }
            if (end.HasValue)
            {
                query = query.Where(d => d.EndDate.Date <= end.Value);
            }

            var totalRecords = await query.CountAsync();

            page = Math.Max(page, 1);

            var daysOffAndVacations = await query
                .OrderBy(d => d.StartDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;

            return View(new DaysOffAndVacationsIndexViewModel
            {
                DaysOffAndVacations = daysOffAndVacations,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                    PageSize = pageSize
                }
            });
        }

        // GET: DaysOffAndVacations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysOffAndVacations = await _context.DaysOffAndVacations
                .FirstOrDefaultAsync(m => m.DayOffVacationId == id);
            if (daysOffAndVacations == null)
            {
                return NotFound();
            }

            return View(daysOffAndVacations);
        }

        // GET: DaysOffAndVacations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DaysOffAndVacations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DayOffVacationId,StaffId,StartDate,EndDate,Reason,Status")] DaysOffAndVacations daysOffAndVacations, string password)
        {
            const string AdminPassword = "1234";

            if (daysOffAndVacations.Status != null && password != AdminPassword)
            {
                TempData["ErrorMessage"] = "Invalid password. Status creation failed.";
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                _context.Add(daysOffAndVacations);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Record created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(daysOffAndVacations);
        }

        // GET: DaysOffAndVacations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysOffAndVacations = await _context.DaysOffAndVacations.FindAsync(id);
            if (daysOffAndVacations == null)
            {
                return NotFound();
            }
            return View(daysOffAndVacations);
        }

        // POST: DaysOffAndVacations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DayOffVacationId,StaffId,StartDate,EndDate,Reason,Status")] DaysOffAndVacations daysOffAndVacations, string password)
        {
            const string AdminPassword = "1234";

            if (id != daysOffAndVacations.DayOffVacationId)
            {
                return NotFound();
            }

            if (daysOffAndVacations.Status != null && password != AdminPassword)
            {
                TempData["ErrorMessage"] = "Invalid password. Status update failed.";
                return RedirectToAction(nameof(Edit), new { id = id });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daysOffAndVacations);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Status updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaysOffAndVacationsExists(daysOffAndVacations.DayOffVacationId))
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
            return View(daysOffAndVacations);
        }

        // GET: DaysOffAndVacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysOffAndVacations = await _context.DaysOffAndVacations
                .FirstOrDefaultAsync(m => m.DayOffVacationId == id);
            if (daysOffAndVacations == null)
            {
                return NotFound();
            }

            return View(daysOffAndVacations);
        }

        // POST: DaysOffAndVacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daysOffAndVacations = await _context.DaysOffAndVacations.FindAsync(id);
            if (daysOffAndVacations != null)
            {
                _context.DaysOffAndVacations.Remove(daysOffAndVacations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaysOffAndVacationsExists(int id)
        {
            return _context.DaysOffAndVacations.Any(e => e.DayOffVacationId == id);
        }
    }

    // PagingInfo sınıfı sayfalama bilgilerini taşır
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }

    // ViewModel sınıfı, sayfalama ve listeyi taşır
    public class DaysOffAndVacationsIndexViewModel
    {
        public IEnumerable<DaysOffAndVacations> DaysOffAndVacations { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}





