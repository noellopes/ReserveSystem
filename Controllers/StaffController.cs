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
    public class StaffController : Controller
    {
        private readonly ReserveSystemContext _context;

        public StaffController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index(string searchString,int page = 1, int pageSize = 3)
        {

            var staffQuery = _context.StaffModel.Include(s => s.Job).AsQueryable();

            // Filter by searchString if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                staffQuery = staffQuery.Where(s =>
                    s.Staff_Name.Contains(searchString) ||
                    s.Staff_Email.Contains(searchString) ||
                    s.Staff_Phone.Contains(searchString));
            }

            var totalItems = await staffQuery.CountAsync();

            var staffList = await staffQuery
                                  .Include(s => s.Job)
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            var pagingInfo = new PagingInfo
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = page
            };

            
            ViewBag.PagingInfo = pagingInfo;

            return View(staffList);
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel
                .Include(s => s.Job)
                .FirstOrDefaultAsync(m => m.Staff_Id == id);
            if (staffModel == null)
            {
                return NotFound();
            }

            return View(staffModel);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            ViewData["JobId_FK"] = new SelectList(_context.JobModel, "jobID", "jobName");
            ViewBag.DrivingLicenseGrades = new List<string> { "AM", "A1", "A2", "A", "B", "B1", "C", "C1", "D", "D1", "E", "F", "G" };

            var model = new StaffModel
            {
                Staff_Password = "defaultpassword"
                

            };
            return View(model);
        }

        // POST: Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Staff_Id,Staff_Name,BirthDate,Staff_Email,Staff_Phone,Staff_Password,jobID_FK,StartFunctionsDate,EndFunctionsDate,DrivingLicenseGrades,DriverLicenseExpirationDate,DaysOffVacationCount")] StaffModel staffModel, List<string>? DrivingLicenseGrades)
        {
            if (ModelState.IsValid)
            {
                staffModel.DrivingLicenseGrades = DrivingLicenseGrades;
                _context.Add(staffModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["jobID_FK"] = new SelectList(_context.JobModel, "jobID", "jobName", staffModel.jobID_FK);
            ViewBag.DrivingLicenseGrades = new List<string> { "AM", "A1", "A2", "A", "B", "B1", "C", "C1", "D", "D1", "E", "F", "G" };
            return View(staffModel);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel.FindAsync(id);
            if (staffModel == null)
            {
                return NotFound();
            }
            ViewData["jobID_FK"] = new SelectList(_context.JobModel, "jobID", "jobName", staffModel.jobID_FK);
            ViewBag.DrivingLicenseGrades = new List<string> { "AM", "A1", "A2", "A", "B", "B1", "C", "C1", "D", "D1", "E", "F", "G" };
            return View(staffModel);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Staff_Id,Staff_Name,BirthDate,Staff_Email,Staff_Phone,Staff_Password,jobID_FK,StartFunctionsDate,EndFunctionsDate,DrivingLicenseGrades,DriverLicenseExpirationDate,DaysOffVacationCount")] StaffModel staffModel)
        {
            if (id != staffModel.Staff_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["jobID_FK"] = new SelectList(_context.JobModel, "jobID", "jobName", staffModel.jobID_FK);
            ViewBag.DrivingLicenseGrades = new List<string> { "AM", "A1", "A2", "A", "B", "B1", "C", "C1", "D", "D1", "E", "F", "G" };
            return View(staffModel);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffModel = await _context.StaffModel
                .Include(s => s.Job)
                .FirstOrDefaultAsync(m => m.Staff_Id == id);
            if (staffModel == null)
            {
                return NotFound();
            }

            return View(staffModel);
        }

        // POST: Staff/Delete/5
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
