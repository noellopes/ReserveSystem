using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "manager@example.com" && password == "password123") // Static
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password. Please try again.";
                return View();
            }
        }

        // GET: Manager/Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: Manager/CreateEmployee
        public IActionResult CreateEmployee()
        {
            return View();
        }

        // POST: Manager/CreateEmployee
        [HttpPost]
        public IActionResult CreateEmployee(Manager manager)
        {
            // Logic for creating a new employee goes here.
            // If you need to save the employee to the database, do that here.
            return RedirectToAction("Dashboard");
        }

        public IActionResult AllocateEmployee(int employeeId, int scheduleId)
        {
            return RedirectToAction("Dashboard");
        }

        public IActionResult NotifyEmployee(int employeeId)
        {
            return RedirectToAction("Dashboard");
        }

        public IActionResult RequestDayOff(int employeeId)
        {
            return RedirectToAction("Dashboard");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}