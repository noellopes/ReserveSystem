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
    public class StaffModelsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public StaffModelsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: StaffModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffModel.ToListAsync());
        }

        // GET: StaffModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel
                .FirstOrDefaultAsync(m => m.Staff_Id == id);
            if (staffModel == null)
            {
                return NotFound();
            }

            return View(staffModel);
        }

        // GET: StaffModels/Create
        public IActionResult Create()
        {

            //ViewBag.Jobs = new SelectList(_context.Jobs, "JobId", "Name");
            ViewBag.DrivingLicenseGrades = new List<string> { "AM", "A1", "A2", "A", "B", "B1", "C", "C1", "D", "D1", "E", "F", "G" };

            var model = new StaffModel
            {
                Staff_Password = "defaultpassword" // Definir o valor padrão
            };
            return View(model);
            
        }


        // POST: StaffModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Staff_Id,Staff_Name,BirthDate,Staff_Email,Staff_Phone,Staff_Password,Job_Id,DriverLicenseExpirationDate,DrivingLicenseGrades")] StaffModel staffModel, List<string>? DrivingLicenseGrades)
        {
           
            if (ModelState.IsValid)
            {
                staffModel.DrivingLicenseGrades = DrivingLicenseGrades;
                //ViewBag.Jobs = new SelectList(_context.Jobs.ToList(), "Job_Id", "Job_Name", staff.Job_Id);
                _context.Add(staffModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
                
            }
            ViewBag.DrivingLicenseGrades = new List<string> { "AM", "A1", "A2", "A", "B", "B1", "C", "C1", "D", "D1", "E", "F", "G" };
            return View(staffModel);

        }

        // GET: StaffModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.DrivingLicenseGrades = new List<string> { "AM", "A1", "A2", "A", "B", "B1", "C", "C1", "D", "D1", "E", "F", "G"};
            if (id == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel.FindAsync(id);
            if (staffModel == null)
            {
                return NotFound();
            }
            return View(staffModel);
        }

        // POST: StaffModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Staff_Id,Staff_Name,BirthDate,Staff_Email,Staff_Phone,Staff_Password,Job_Id,DriverLicenseExpirationDate,DrivingLicenseGrades")] StaffModel staffModel)
        {
            
            
            if (id != staffModel.Staff_Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
             
                try
                {
                    ViewBag.DrivingLicenseGrades = new List<string> { "AM", "A1", "A2", "A", "B", "B1", "C", "C1", "D", "D1", "E", "F", "G"};
                    _context.Update(staffModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffModelExists(staffModel.Staff_Id))
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
            return View(staffModel);
        }

        // GET: StaffModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel
                .FirstOrDefaultAsync(m => m.Staff_Id == id);
            if (staffModel == null)
            {
                return NotFound();
            }

            return View(staffModel);
        }

        // POST: StaffModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffModel = await _context.StaffModel.FindAsync(id);
            if (staffModel != null)
            {
                _context.StaffModel.Remove(staffModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffModelExists(int id)
        {
            return _context.StaffModel.Any(e => e.Staff_Id == id);
        }
    }
}
