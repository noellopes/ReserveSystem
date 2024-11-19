using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Data;
using ReserveSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ReserveSystem.Controllers
{
    public class DaysOffAndVacationsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public DaysOffAndVacationsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // List all requests
        public async Task<IActionResult> Index()
        {
            var requests = await _context.DaysOffAndVacations
                .Include(d => d.Staff)
                .ToListAsync();
            return View(requests);
        }

        // New permission request creation page (GET)
        public IActionResult Create()
        {
            // We send the staff list with ViewBag.
            ViewBag.StaffList = new SelectList(_context.Staff, "StaffId", "Name");
            return View();
        }


        // Create new permission request (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DaysOffAndVacations model)
        {

            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // View request details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var request = await _context.DaysOffAndVacations.FindAsync(id);

            if (request == null) return NotFound();

            return View(request);
        }

        // Confirm the request
        [HttpPost]
        public async Task<IActionResult> ConfirmRequest(int id)
        {
            var request = await _context.DaysOffAndVacations.FindAsync(id);
            if (request == null) return NotFound();

            // Approval process
            request.Status = "Approved"; // Add the Status property if it exists in the database
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Reject request
        [HttpPost]
        public async Task<IActionResult> DenyRequest(int id)
        {
            var request = await _context.DaysOffAndVacations.FindAsync(id);
            if (request == null) return NotFound();

            // Rejection process
            request.Status = "Rejected"; // Add the Status property if it exists in the database
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}