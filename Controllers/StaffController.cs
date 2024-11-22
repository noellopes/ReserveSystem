using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            var staffList = await _context.Staff.Include(s => s.Job).ToListAsync();
            return View(staffList);
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.Job)
                .FirstOrDefaultAsync(m => m.StaffID == id);

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,JobId,StaffName,StaffEmail,StaffDept,StaffPhone,StaffPassword,StartFunctionsDate,EndFunctionsDate,DaysOffVacation")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staff/Edit/5
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

            return View(staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,JobId,StaffName,StaffEmail,StaffDept,StaffPhone,StaffPassword,StartFunctionsDate,EndFunctionsDate,DaysOffVacation")] Staff staff)
        {
            if (id != staff.StaffID)
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
                    if (!StaffExists(staff.StaffID))
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
            return View(staff);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.Job)
                .FirstOrDefaultAsync(m => m.StaffID == id);

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffID == id);
        }

        // SELECT: Staff/Search
        public async Task<IActionResult> Search(string searchString)
        {
            var staffList = from s in _context.Staff.Include(s => s.Job)
                            select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                staffList = staffList.Where(s => s.StaffName.Contains(searchString) || s.StaffDept.Contains(searchString));
            }

            return View("Index", await staffList.ToListAsync());
        }

        // CONSULT: Staff/Consult
        public async Task<IActionResult> Consult(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.Job)
                .FirstOrDefaultAsync(m => m.StaffID == id);

            if (staff == null)
            {
                return NotFound();
            }

            // Örnek: İlgili personelin tatil günlerinin detaylı incelemesi gibi özel bir işlem
            ViewBag.ConsultMessage = $"Staff {staff.StaffName} has {staff.DaysOffVacation} vacation days remaining.";

            return View(staff);
        }
    }
}
