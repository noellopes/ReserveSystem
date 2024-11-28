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
        public async Task<IActionResult> Index(string searchQuery)
        {
            var clients = _context.Client.AsQueryable();

            // If searchQuery is provided, filter by Email or Identification
            if (!string.IsNullOrEmpty(searchQuery))
            {
                clients = clients.Where(c =>
                    c.Email.Contains(searchQuery) ||
                    c.Identification.Contains(searchQuery));
            }
            var clientList = await clients.ToListAsync();

            if (Request.Headers.XRequestedWith == "XMLHttpRequest")
            {
                // Return only the table rows as a partial view for AJAX requests
                return PartialView("_ClientTableBody", clientList);
            }
            return View(clientList);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewBag.Entity = "Cliente";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }

            var clientModel = await _context.Client
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientModel == null)
            {
                ViewBag.Entity = "Cliente";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }
            _context.Client.Remove(clientModel);
            await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Create([Bind("ClienteId,Name,Phone,Address,Email,Identification,Password, IdentificationType")] ClientModel cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingClient = await _context.Client
                    .FirstOrDefaultAsync(c => c.Email == cliente.Email);

                    if (existingClient != null)
                    {
                        ModelState.AddModelError("Email", "Invalid email. Please verify and try again.");
                        return View(cliente);
                    }
                    if (cliente.IdentificationType == "NIF")
                    {
                        if (!Validator.IsNifValid(cliente.Identification))
                        {
                            ModelState.AddModelError("Identification", "Identification Invalid or NIF cannot be less or greater than 9 digits");
                            return View(cliente);
                        }
                    }
                    else if(cliente.IdentificationType == "IDCard")
                    {
                        if (!Validator.IsIDCardValid(cliente.Identification))
                        {
                            ModelState.AddModelError("Identification", "Identification Invalid or ID Card number cannot be lesser than 8 or greater than 18 digits");
                            return View(cliente);
                        }
                    }
                    else if(cliente.IdentificationType == "Passport")
                    {
                        if (!Validator.IsPassportValid(cliente.Identification))
                        {
                            ModelState.AddModelError("Identification", "Identification Invalid or Passport number cannot be lesser than 8 digits or greater than 12 digits");
                            return View(cliente);
                        }
                    }
                    var isDuplicate = await _context.Client.AnyAsync(c => c.Identification == cliente.Identification);
                    if (isDuplicate)
                    {
                        ModelState.AddModelError("Identification", "Invalid identification details. Please verify and try again.");
                        return View(cliente);
                    }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Name,Phone,Address,Email,Identification,Password,IdentificationType")] ClientModel clientModel)
        {
            if (id != clientModel.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingClient = await _context.Client.FindAsync(id);

                    if (existingClient == null)
                    {
                        ViewBag.Entity = "Cliente";
                        ViewBag.Controller = "Client";
                        ViewBag.Action = "Index";
                        return View("EntityNoLongerExists");
                    }

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
                ViewBag.Entity = "Cliente";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("DeletedSuccess");
            }

            var cliente = await _context.Client
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                ViewBag.Entity = "Cliente";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("DeletedSuccess");
            }
            _context.Client.Remove(cliente);
            await _context.SaveChangesAsync();
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
            
            await _context.SaveChangesAsync();
            return View("DeletedSuccess");
        }

        private bool ClientModelExists(int id)
        {
            return _context.Client.Any(e => e.ClienteId == id);
        }

    }
}
