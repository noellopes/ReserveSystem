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
    public class JobTestController : Controller
    {
        private readonly ReserveSystemContext _context;

        public JobTestController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: JobTestModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobTestModel.ToListAsync());
        }

        // GET: JobTestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTestModel = await _context.JobTestModel
                .FirstOrDefaultAsync(m => m.Job_ID == id);
            if (jobTestModel == null)
            {
                return NotFound();
            }

            return View(jobTestModel);
        }

        // GET: JobTestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobTestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Job_ID,Job_Name,Job_Description")] JobTestModel jobTestModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobTestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobTestModel);
        }

        // GET: JobTestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTestModel = await _context.JobTestModel.FindAsync(id);
            if (jobTestModel == null)
            {
                return NotFound();
            }
            return View(jobTestModel);
        }

        // POST: JobTestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Job_ID,Job_Name,Job_Description")] JobTestModel jobTestModel)
        {
            if (id != jobTestModel.Job_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobTestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobTestModelExists(jobTestModel.Job_ID))
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
            return View(jobTestModel);
        }

        // GET: JobTestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTestModel = await _context.JobTestModel
                .FirstOrDefaultAsync(m => m.Job_ID == id);
            if (jobTestModel == null)
            {
                return NotFound();
            }

            return View(jobTestModel);
        }

        // POST: JobTestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobTestModel = await _context.JobTestModel.FindAsync(id);
            if (jobTestModel != null)
            {
                _context.JobTestModel.Remove(jobTestModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobTestModelExists(int id)
        {
            return _context.JobTestModel.Any(e => e.Job_ID == id);
        }
    }
}
