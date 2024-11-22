using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Linq;

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
        public IActionResult Index()
        {
            var jobs = _context.Job.ToList();
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
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Job.Add(job);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Job/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var job = _context.Job.Find(id);
            if (job == null)
                return NotFound();

            return View(job);
        }

        // POST: Job/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Job.Update(job);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Job/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var job = _context.Job.Find(id);
            if (job == null)
                return NotFound();

            return View(job);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var job = _context.Job.Find(id);
            if (job == null)
                return NotFound();

            _context.Job.Remove(job);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Custom: consult_job
        // GET: ConsultJob
        public IActionResult ConsultJob()
        {
            var jobs = _context.Job.ToList(); // Tüm işleri çek
            return View(jobs);
        }


        // Custom: select_job
        // GET: SelectJobByName
        public IActionResult SelectJobByName()
        {
            return View();
        }

        // POST: SelectJobByName
        [HttpPost]
        public IActionResult SelectJobByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Message = "Job name cannot be empty.";
                return View();
            }

            var jobs = _context.Job
                               .Where(j => j.JobName.Contains(name))
                               .ToList();

            if (!jobs.Any())
            {
                ViewBag.Message = "No jobs found with the specified name.";
                return View();
            }

            return View(jobs);
        }

    }
}
