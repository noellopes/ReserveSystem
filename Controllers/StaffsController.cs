﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class StaffsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public StaffsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index(string searchName, int page = 1)
        {
            int pageSize = 4;

            var query = _context.Staff.Include(s => s.job).AsQueryable();

            // Filtrar por nome
            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(s => s.StaffName.Contains(searchName));
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .OrderBy(s => s.StaffName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new StaffViewModel
            {
                Staffs = items,
                SearchName = searchName,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.job)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobDescription");
            return View();
        }

        // POST: Staffs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,StaffName,StaffEmail,StaffPhone,StaffDriversLicense,StaffDriversLicenseExpiringDate,StaffDateOfBirth,StaffPassword,StartFunctionsDate,EndFunctionsDate,DaysOfVacationCount,IsActive,JobId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();

                // Redireciona para a página "Registration Complete", passando o StaffId
                return RedirectToAction("RegistrationComplete", "Staffs", new { staffId = staff.StaffId });
            }
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobDescription", staff.JobId);
            return View(staff);
        }

        public async Task<IActionResult> RegistrationComplete(int staffId)
        {
            var staff = await _context.Staff
                .Include(s => s.job)
                .FirstOrDefaultAsync(s => s.StaffId == staffId);

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }


        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobDescription", staff.JobId);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,StaffName,StaffEmail,StaffPhone,StaffDriversLicense,StaffDriversLicenseExpiringDate,StaffDateOfBirth,StaffPassword,StartFunctionsDate,EndFunctionsDate,DaysOfVacationCount,IsActive,JobId")] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Redireciona para a página de sucesso passando o StaffId
                return RedirectToAction("EditSuccess", new { staffId = staff.StaffId });
            }
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobDescription", staff.JobId);
            return View(staff);
        }

        public async Task<IActionResult> EditSuccess(int staffId)
        {
            var staff = await _context.Staff
                .Include(s => s.job)
                .FirstOrDefaultAsync(s => s.StaffId == staffId);

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.job)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                await _context.SaveChangesAsync();
            }

            // Redireciona para a página de confirmação de exclusão
            return RedirectToAction("DeleteSuccess", new { staffName = staff?.StaffName });
        }

        // GET: Staffs/DeleteSuccess
        public IActionResult DeleteSuccess(string staffName)
        {
            ViewBag.StaffName = staffName;
            return View();
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffId == id);
        }
    }
}