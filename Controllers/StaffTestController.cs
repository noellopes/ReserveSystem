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
    public class StaffTestController : Controller
    {
        private readonly ReserveSystemContext _context;

        public StaffTestController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: StaffTestModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffTestModel.ToListAsync());
        }

        // GET: StaffTestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTestModel = await _context.StaffTestModel
                .FirstOrDefaultAsync(m => m.Staff_Id == id);
            if (staffTestModel == null)
            {
                return NotFound();
            }

            return View(staffTestModel);
        }

        // GET: StaffTestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffTestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Staff_Id,Staff_Name,Job_ID")] StaffTestModel staffTestModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffTestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffTestModel);
        }

        // GET: StaffTestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTestModel = await _context.StaffTestModel.FindAsync(id);
            if (staffTestModel == null)
            {
                return NotFound();
            }
            return View(staffTestModel);
        }

        // POST: StaffTestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Staff_Id,Staff_Name,Job_ID")] StaffTestModel staffTestModel)
        {
            if (id != staffTestModel.Staff_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffTestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffTestModelExists(staffTestModel.Staff_Id))
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
            return View(staffTestModel);
        }

        // GET: StaffTestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTestModel = await _context.StaffTestModel
                .FirstOrDefaultAsync(m => m.Staff_Id == id);
            if (staffTestModel == null)
            {
                return NotFound();
            }

            return View(staffTestModel);
        }

        // POST: StaffTestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffTestModel = await _context.StaffTestModel.FindAsync(id);
            if (staffTestModel != null)
            {
                _context.StaffTestModel.Remove(staffTestModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffTestModelExists(int id)
        {
            return _context.StaffTestModel.Any(e => e.Staff_Id == id);
        }
    }
}
