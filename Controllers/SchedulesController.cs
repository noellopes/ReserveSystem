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
    public class SchedulesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public SchedulesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 3)
        {
            var ScheduleQuery = _context.ScheduleModel.Include(s => s.Staff).Include(s => s.TypeOfShedule).AsQueryable();

            // Filter by searchString if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                ScheduleQuery = ScheduleQuery.Where(s =>
                    s.Date.ToString("yyyyMMddHHmmss").Contains(searchString) ||
                    s.Staff.Staff_Name.Contains(searchString));
            }

            var totalItems = await ScheduleQuery.CountAsync();

            var ScheduleList = await ScheduleQuery
            .Include(s => s.Staff)
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

            return View(ScheduleList);
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.ScheduleModel
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.StaffModel, "Staff_Id", "Staff_Name");
            ViewData["TypeOfSheduleId"] = new SelectList(_context.TypeOfSchedule, "TypeOfScheduleId", "TypeOfScheduleName");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId,StaffId,TypeOfSheduleId,Date,StartShiftTime,EndShiftTime,Presence")] Schedule schedule)
        {
            if (!ModelState.IsValid && schedule.Staff==null && schedule.TypeOfShedule==null)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.ScheduleModel.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleId,StaffId,TypeOfSheduleId,Date,StartShiftTime,EndShiftTime,Presence")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
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
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.ScheduleModel
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.ScheduleModel.FindAsync(id);
            if (schedule != null)
            {
                _context.ScheduleModel.Remove(schedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.ScheduleModel.Any(e => e.ScheduleId == id);
        }
    }
}
