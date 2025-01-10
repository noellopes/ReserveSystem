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
    public class JobModelsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public JobModelsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: JobModels
        public async Task<IActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            ViewData["Title"] = "Job Listings"; // Set the page title
            ViewData["SearchString"] = searchString; // Pass the search term to the view

            var jobsQuery = _context.JobModel.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                jobsQuery = jobsQuery.Where(j =>
                    j.jobName.Contains(searchString) ||
                    j.jobDescription.Contains(searchString));
            }

            // Pagination
            var totalJobs = await jobsQuery.CountAsync();
            var jobs = await jobsQuery
                .OrderBy(j => j.jobID)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new JobIndexViewModel
            {
                Jobs = jobs,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(totalJobs / (double)pageSize)
            };

            return View(viewModel);
        }

        // Other methods (Details, Create, Edit, Delete) remain unchanged
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel
                .FirstOrDefaultAsync(m => m.jobID == id);
            if (jobModel == null)
            {
                return NotFound();
            }

            return View(jobModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("jobID,jobName,jobDescription")] JobModel jobModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel.FindAsync(id);
            if (jobModel == null)
            {
                return NotFound();
            }
            return View(jobModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("jobID,jobName,jobDescription")] JobModel jobModel)
        {
            if (id != jobModel.jobID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobModelExists(jobModel.jobID))
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
            return View(jobModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel
                .FirstOrDefaultAsync(m => m.jobID == id);
            if (jobModel == null)
            {
                return NotFound();
            }

            return View(jobModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobModel = await _context.JobModel.FindAsync(id);
            if (jobModel != null)
            {
                _context.JobModel.Remove(jobModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobModelExists(int id)
        {
            return _context.JobModel.Any(e => e.jobID == id);
        }
    }
}
