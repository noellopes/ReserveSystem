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

            // Obter a data atual
            var today = DateTime.Today;

            // Obter horários ocupados para o dia de hoje
            var busyHours = _context.Cleaning_Schedule
                                    .Where(c => c.DateServices == today)
                                    .Select(c => new { c.StartTime, c.EndTime })
                                    .ToList();

            // Obter horários disponíveis
            var availableTimes = GetAvailableTimeSlots(busyHours);

            ViewBag.AvailableTimes = availableTimes;

            return View();
        }

        // POST: Cleaning_Schedule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CleaningScheduleId,RoomBookingId,ClientId,StaffId,DateServices,StartTime,EndTime,CleaningDone,CleaningDesired,PreferredCleaningStartTime,PreferredCleaningEndTime")] Cleaning_Schedule cleaning_Schedule)
        {
            if (ModelState.IsValid)
            {
                // Verificar a disponibilidade do funcionário
                var isStaffAvailable = !_context.Cleaning_Schedule.Any(cs => cs.StaffId == cleaning_Schedule.StaffId &&
                                                                            cs.DateServices == cleaning_Schedule.DateServices &&
                                                                            cs.StartTime < cleaning_Schedule.EndTime &&
                                                                            cs.EndTime > cleaning_Schedule.StartTime);

                if (isStaffAvailable)
                {
                    _context.Add(cleaning_Schedule);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "The staff member is not available for the selected time.");
                }
            }

            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Client_Adress", cleaning_Schedule.ClientId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffDriversLicense", cleaning_Schedule.StaffId);
            return View(cleaning_Schedule);
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

        private List<string> GetAvailableTimeSlots(List<dynamic> busyHours)
        {
            var allSlots = new List<string>();
            var workStart = 8; // 8:00 AM
            var workEnd = 18; // 6:00 PM
            var slotDuration = 1; // 1 hour intervals

            for (int h = workStart; h < workEnd; h++)
            {
                for (int m = 0; m < 60; m += slotDuration * 60)
                {
                    var start = new DateTime(2025, 1, 1, h, m, 0);  // Fecha genérica para calcular o horário
                    var end = start.AddHours(slotDuration);

                    bool isBusy = busyHours.Any(b => start < b.EndTime && end > b.StartTime);  // Verifica se o horário está ocupado

                    if (!isBusy)
                    {
                        allSlots.Add($"{start:HH:mm} - {end:HH:mm}");
                    }
                }
            }
            return allSlots;
        }
    }
}
