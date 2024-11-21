using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly ReserveSystemContext _context;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly PasswordHasher<ClientModel> passwordHasher;

        public ClientController(ReserveSystemContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            //_signInManager = signInManager;
            //_userManager = userManager;
            //this.passwordHasher = passwordHasher;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            return View(await _context.Client.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.Client
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Name,Phone,Address,Email,NIF,Password")] ClientModel cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!NifValidator.IsNifValid(cliente.NIF))
                    {
                        ModelState.AddModelError("NIF", "NIF Inválido");
                        return View(cliente);
                    }
                    //cliente.Password = passwordHasher.HashPassword(cliente, cliente.Password);
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return View(cliente);
                }
            }
            return View(cliente);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Client.FindAsync(id);
            if (author == null)
            {
                ViewBag.Entity = "Cliente";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }
            return View(author);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Name,Phone,Address,Email,NIF,Password")] ClientModel clientModel)
        {
            if (id != clientModel.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientModelExists(clientModel.ClienteId))
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
            return View(clientModel);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Invalid client ID.";
                return RedirectToAction(nameof(Index));
            }

            var cliente = await _context.Client
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                TempData["ErrorMessage"] = "Client not found.";
                return RedirectToAction(nameof(Index));

                ViewBag.Entity = "Cliente";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("DeletedSuccess");
            }

            return View(cliente);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Client.FindAsync(id);
            if (cliente != null)
            {
                _context.Client.Remove(cliente);
                
            }
            ViewBag.Entity = "Cliente";
            ViewBag.Controller = "Client";
            ViewBag.Action = "Index";
            return View("DeletedSuccess");

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientModelExists(int id)
        {
            return _context.Client.Any(e => e.ClienteId == id);
        }

    }
}
