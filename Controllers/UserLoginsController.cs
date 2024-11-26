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
    public class UserLoginsController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public UserLoginsController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: UserLogins
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserLogin.ToListAsync());
        }

        // GET: UserLogins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogin
                .FirstOrDefaultAsync(m => m.Login_id == id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }

        // GET: UserLogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Login_id,Staff_id,Password")] UserLogin userLogin)
        {
            if (_context.UserLogin.Any(u => u.Staff_id == userLogin.Staff_id))
            {
                ModelState.AddModelError("Staff_id", "A user with this Staff ID already exists.");
                return View(userLogin);
            }

            if (ModelState.IsValid)
            {
                _context.Add(userLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLogin);
        }


        // GET: UserLogins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogin.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }
            return View(userLogin);
        }

        // POST: UserLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Login_id,Staff_id,Password")] UserLogin userLogin)
        {
            if (id != userLogin.Login_id)
            {
                return NotFound();
            }

            if (_context.UserLogin.Any(u => u.Staff_id == userLogin.Staff_id && u.Login_id != id))
            {
                ModelState.AddModelError("Staff_id", "A user with this Staff ID already exists.");
                return View(userLogin);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLoginExists(userLogin.Login_id))
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
            return View(userLogin);
        }


        // GET: UserLogins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogin
                .FirstOrDefaultAsync(m => m.Login_id == id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }

        // POST: UserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userLogin = await _context.UserLogin.FindAsync(id);
            if (userLogin != null)
            {
                _context.UserLogin.Remove(userLogin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLoginExists(int id)
        {
            return _context.UserLogin.Any(e => e.Login_id == id);
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Staff_id, string Password)
        {
            var user = _context.UserLogin
                .FirstOrDefault(u => u.Staff_id.ToString() == Staff_id && u.Password == Password);

            if (user != null)
            {
                // Usuario encontrado
                ViewBag.Message = "Log in correct.";
                return View(); // Devuelve la vista con un mensaje
            }

            // Usuario no encontrado
            ViewBag.Error = "Incorrect user or password.";
            return View(); // Devuelve la vista con el error
        }
    }
}
