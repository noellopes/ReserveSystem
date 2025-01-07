using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class Cleaning_ScheduleController : Controller
    {
        private readonly ReserveSystemContext _context;

        public Cleaning_ScheduleController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Cleaning_Schedule
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.Cleaning_Schedule.Include(c => c.client).Include(c => c.staffMembers);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: Cleaning_Schedule/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense");

            ViewBag.AvailableTimes = new List<string>
    {
        "08:00 - 09:00",
        "09:00 - 10:00",
        "10:00 - 11:00",
        "11:00 - 12:00",
        "14:00 - 15:00",
        "15:00 - 16:00",
        "16:00 - 17:00"
    };

            return View();
        }

        // POST: Cleaning_Schedule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CleaningScheduleId,RoomBookingId,ClientId,StaffId,DateServices,StartTime,EndTime,CleaningDone,CleaningDesired,PreferredCleaningStartTime,PreferredCleaningEndTime")] Cleaning_Schedule cleaning_Schedule)
        {
            if (ModelState.IsValid)
            {
                // Ajustar automaticamente o escalonamento com base nas preferências do cliente
                var availableStaff = AdjustStaffSchedule(cleaning_Schedule);

                if (availableStaff != null)
                {
                    cleaning_Schedule.StaffId = availableStaff.StaffId;
                    _context.Add(cleaning_Schedule);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "No staff members are available for the selected time and preferences.");
                }
            }

            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress", cleaning_Schedule.ClientId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", cleaning_Schedule.StaffId);
            return View(cleaning_Schedule);
        }

        private Staff? AdjustStaffSchedule(Cleaning_Schedule cleaning_Schedule)
        {
            // procura os funcionários disponíveis que atendam às preferências de horários
            var availableStaff = _context.Staff
                .Where(s => !_context.Cleaning_Schedule.Any(cs => cs.StaffId == s.StaffId &&
                                                                  cs.DateServices == cleaning_Schedule.DateServices &&
                                                                  cs.StartTime < cleaning_Schedule.EndTime &&
                                                                  cs.EndTime > cleaning_Schedule.StartTime))
                .ToList();

            foreach (var staff in availableStaff)
            {
                // Verificar se o funcionário está dentro do horário preferido do cliente
                if (cleaning_Schedule.PreferredCleaningStartTime.HasValue &&
                    cleaning_Schedule.PreferredCleaningEndTime.HasValue)
                {
                    var preferredStart = cleaning_Schedule.PreferredCleaningStartTime.Value;
                    var preferredEnd = cleaning_Schedule.PreferredCleaningEndTime.Value;

                    if (cleaning_Schedule.StartTime >= preferredStart && cleaning_Schedule.EndTime <= preferredEnd)
                    {
                        return staff; // Encontrou um funcionário disponível e que respeita as preferências
                    }
                }
                else
                {
                    // Se não houver preferências, retornar o primeiro disponível
                    return staff;
                }
            }

            return null; // Nenhum funcionário disponível dentro das preferências
        }

        // GET: Cleaning_Schedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaning_Schedule = await _context.Cleaning_Schedule.FindAsync(id);
            if (cleaning_Schedule == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress", cleaning_Schedule.ClientId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", cleaning_Schedule.StaffId);
            return View(cleaning_Schedule);
        }

        // POST: Cleaning_Schedule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CleaningScheduleId,RoomBookingId,ClientId,StaffId,DateServices,StartTime,EndTime,CleaningDone,CleaningDesired,PreferredCleaningStartTime,PreferredCleaningEndTime")] Cleaning_Schedule cleaning_Schedule)
        {
            if (id != cleaning_Schedule.CleaningScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cleaning_Schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cleaning_ScheduleExists(cleaning_Schedule.CleaningScheduleId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress", cleaning_Schedule.ClientId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", cleaning_Schedule.StaffId);
            return View(cleaning_Schedule);
        }

        // GET: Cleaning_Schedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cleaning_Schedule = await _context.Cleaning_Schedule
                .Include(c => c.client)
                .Include(c => c.staffMembers)
                .FirstOrDefaultAsync(m => m.CleaningScheduleId == id);
            if (cleaning_Schedule == null)
            {
                return NotFound();
            }

            return View(cleaning_Schedule);
        }

        // POST: Cleaning_Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cleaning_Schedule = await _context.Cleaning_Schedule.FindAsync(id);
            _context.Cleaning_Schedule.Remove(cleaning_Schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cleaning_ScheduleExists(int id)
        {
            return _context.Cleaning_Schedule.Any(e => e.CleaningScheduleId == id);
        }
    }
}
