using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public SchedulesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index(int page = 1, string searchName = null)
        {
            int pageSize = 3;

            // Filtrar os agendamentos com base no nome do staff (se fornecido)
            var query = _context.Schedules
                .Include(s => s.staff)
                .Include(s => s.typeOfSchedule)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(s => s.staff.StaffName.Contains(searchName));
            }

            var totalSchedules = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalSchedules / (double)pageSize);

            var schedules = await query
                .OrderBy(s => s.StartShiftTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new SchedulesViewModel
            {
                Schedules = schedules,
                CurrentPage = page,
                TotalPages = totalPages,
                SearchName = searchName
            };

            return View(viewModel);
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules
                .Include(s => s.staff)
                .Include(s => s.typeOfSchedule)
                .FirstOrDefaultAsync(m => m.SchedulesId == id);
            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense");
            ViewData["TypeOfScheduleId"] = new SelectList(_context.TypeOfSchedule, "TypeOfScheduleId", "TypeOfScheduleDescription");
            return View();
        }

        // POST: Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchedulesId,StartShiftTime,EndShiftTime,isPrecense,isAvailable,StaffId,TypeOfScheduleId")] Schedules schedules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedules);
                await _context.SaveChangesAsync();

                // Redireciona para a página "Registration Complete", passando o SchedulesId
                return RedirectToAction("RegistrationComplete", "Schedules", new { schedulesId = schedules.SchedulesId });
            }
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffName", schedules.StaffId);
            ViewData["TypeOfScheduleId"] = new SelectList(_context.TypeOfSchedule, "TypeOfScheduleId", "TypeOfScheduleDescription", schedules.TypeOfScheduleId);
            return View(schedules);
        }

        public async Task<IActionResult> RegistrationComplete(int schedulesId)
        {
            var schedules = await _context.Schedules
                .Include(s => s.staff)
                .Include(s => s.typeOfSchedule)
                .FirstOrDefaultAsync(s => s.SchedulesId == schedulesId);

            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules.FindAsync(id);
            if (schedules == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", schedules.StaffId);
            ViewData["TypeOfScheduleId"] = new SelectList(_context.TypeOfSchedule, "TypeOfScheduleId", "TypeOfScheduleDescription", schedules.TypeOfScheduleId);
            return View(schedules);
        }

        // POST: Schedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchedulesId,StartShiftTime,EndShiftTime,isPrecense,isAvailable,StaffId,TypeOfScheduleId")] Schedules schedules)
        {
            if (id != schedules.SchedulesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulesExists(schedules.SchedulesId))
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
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", schedules.StaffId);
            ViewData["TypeOfScheduleId"] = new SelectList(_context.TypeOfSchedule, "TypeOfScheduleId", "TypeOfScheduleDescription", schedules.TypeOfScheduleId);
            return View(schedules);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules
                .Include(s => s.staff)
                .Include(s => s.typeOfSchedule)
                .FirstOrDefaultAsync(m => m.SchedulesId == id);
            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedules = await _context.Schedules.FindAsync(id);
            if (schedules != null)
            {
                _context.Schedules.Remove(schedules);
                await _context.SaveChangesAsync();
            }

            // Redireciona para a página de confirmação de exclusão
            return RedirectToAction("DeleteSuccess", new { itemName = schedules?.StartShiftTime });
        }

        // GET: Schedules/DeleteSuccess
        public IActionResult DeleteSuccess(string itemName)
        {
            ViewBag.ItemName = itemName;
            return View();
        }

        private bool SchedulesExists(int id)
        {
            return _context.Schedules.Any(e => e.SchedulesId == id);
        }
    }
}
