using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveSystem.Controllers
{
    public class JobController : Controller
    {
        private readonly ReserveSystemContext _context;

        public JobController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Job/Index
        public async Task<IActionResult> Index(string search, int page = 1, int pageSize = 10)
        {
            // Filtrelenebilir sorguyu oluştur
            var query = _context.Job.AsQueryable();

            // Eğer arama filtresi varsa, sorguya uygula
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(j => j.JobName.Contains(search) || j.JobDescription.Contains(search));
            }

            // Toplam kayıt sayısını al (filtre uygulanmış)
            var totalRecords = await query.CountAsync();

            // Filtrelenmiş ve sayfalama uygulanmış işleri al
            var jobs = await query
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();

            // ViewBag ile View'e ek bilgiler gönder
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.Search = search; // Arama kutusunda son arama değeri için

            return View(jobs);
        }

        // GET: Job/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Job.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Job/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var job = await _context.Job.FindAsync(id);
            if (job == null)
                return NotFound();

            return View(job);
        }

        // POST: Job/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Job.Update(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var job = await _context.Job.FindAsync(id);
            if (job == null)
                return NotFound();

            return View(job);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Job.FindAsync(id);
            if (job == null)
                return NotFound();

            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ConsultJob()
        {
            var jobs = _context.Job.ToList();
            return View(jobs);
        }
    }
}
