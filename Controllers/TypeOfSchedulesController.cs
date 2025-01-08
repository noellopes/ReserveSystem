using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TypeOfSchedulesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public TypeOfSchedulesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: TypeOfSchedules
        public async Task<IActionResult> Index(int? page, string searchString)
        {
            int pageSize = 10; // Her sayfada gösterilecek kayıt sayısı
            int pageNumber = page ?? 1; // Varsayılan olarak 1. sayfa

            // Sorguyu başlat
            var typeOfSchedulesQuery = _context.TypeOfSchedule.AsQueryable();

            // Eğer arama metni varsa, filtre uygula
            if (!string.IsNullOrEmpty(searchString))
            {
                typeOfSchedulesQuery = typeOfSchedulesQuery.Where(s => s.TypeOfScheduleName.Contains(searchString));
            }

            // Toplam kayıt sayısını hesapla
            int totalItems = await typeOfSchedulesQuery.CountAsync();
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalItems / pageSize);
            ViewData["CurrentPage"] = pageNumber;
            ViewData["SearchString"] = searchString; // Arama metnini View'e gönder

            // Sayfalama işlemi
            var typeOfSchedules = await typeOfSchedulesQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return View(typeOfSchedules); // Listeyi View'e gönder
        }

        // GET: TypeOfSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var typeOfSchedule = await _context.TypeOfSchedule
                .FirstOrDefaultAsync(m => m.TypeOfScheduleId == id);

            if (typeOfSchedule == null) return NotFound();

            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfSchedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfScheduleId,TypeOfScheduleName")] TypeOfSchedule typeOfSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var typeOfSchedule = await _context.TypeOfSchedule.FindAsync(id);
            if (typeOfSchedule == null) return NotFound();

            return View(typeOfSchedule);
        }

        // POST: TypeOfSchedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeOfScheduleId,TypeOfScheduleName")] TypeOfSchedule typeOfSchedule)
        {
            if (id != typeOfSchedule.TypeOfScheduleId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfScheduleExists(typeOfSchedule.TypeOfScheduleId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var typeOfSchedule = await _context.TypeOfSchedule
                .FirstOrDefaultAsync(m => m.TypeOfScheduleId == id);

            if (typeOfSchedule == null) return NotFound();

            return View(typeOfSchedule);
        }

        // POST: TypeOfSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfSchedule = await _context.TypeOfSchedule.FindAsync(id);
            if (typeOfSchedule != null)
            {
                _context.TypeOfSchedule.Remove(typeOfSchedule);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfScheduleExists(int id)
        {
            return _context.TypeOfSchedule.Any(e => e.TypeOfScheduleId == id);
        }
    }
}