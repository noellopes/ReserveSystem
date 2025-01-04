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
        public ClientController(ReserveSystemContext context)
        {
            _context = context;            
        }

        // GET: Client
        public async Task<IActionResult> Index(string searchQuery, int page = 1)
        {
            var clients = _context.Client.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                clients = clients.Where(c =>
                    c.Email.Contains(searchQuery) ||
                    c.NIF.Contains(searchQuery));
            }
            ViewData["SearchQuery"] = searchQuery;
            var clientList = await clients.ToListAsync();

            var bookmodel = new ClientViewModel();
            bookmodel.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = await clients.CountAsync(),
            };
            bookmodel.clientModels = await clients
                .OrderBy(c => c.Name)
                .Skip((bookmodel.PagingInfo.CurrentPage - 1) * bookmodel.PagingInfo.PageSize)
                .Take(bookmodel.PagingInfo.PageSize)
                .ToListAsync();
            return View(bookmodel);
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
        public async Task<IActionResult> Create([Bind("ClienteId,Name,Phone,Address,Email,NIF,IdentificationType,Login,Status")] ClientModel cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingPhone = await _context.Client
                    .FirstOrDefaultAsync(c => c.Phone == cliente.Phone);

                    if (existingPhone != null)
                    {
                        ModelState.AddModelError("Phone", "Invalid Phone number. Please verify and try again.");
                        return View(cliente);
                    }
                    var existingClient = await _context.Client
                    .FirstOrDefaultAsync(c => c.Email == cliente.Email);

                    if (existingClient != null)
                    {
                        ModelState.AddModelError("Email", "Invalid email. Please verify and try again.");
                        return View(cliente);
                    }
                    if (cliente.IdentificationType == "NIF")
                    {
                        if (!Validator.IsNifValid(cliente.NIF))
                        {
                            ModelState.AddModelError("NIF", "Identification number Invalid");
                            return View(cliente);
                        }
                    }
                    else if (cliente.IdentificationType == "Other")
                    {
                        if (string.IsNullOrWhiteSpace(cliente.NIF) || cliente.NIF.Length < 5 || cliente.NIF.Length > 20)
                        {
                            ModelState.AddModelError("NIF", "Invalid Identification number.");
                            return View(cliente);
                        }
                    }

                    var isDuplicateNIF = await _context.Client.AnyAsync(c => c.NIF == cliente.NIF);
                    if (isDuplicateNIF)
                    {
                        ModelState.AddModelError("NIF", "Invalid identification details. Please verify and try again.");
                        return View(cliente);
                    }
                    
                    _context.Add(cliente);
                    TempData["SuccessMessage"] = "Client added successfully!";
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
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Name,Phone,Address,Email,NIF,IdentificationType,Login,Status")] ClientModel clientModel)
        {
            if (id != clientModel.ClienteId)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingClient = await _context.Client.FindAsync(id);

                    if (existingClient == null)
                    {
                        ViewBag.Entity = "Client";
                        ViewBag.Controller = "Client";
                        ViewBag.Action = "Index";
                        return View("EntityNoLongerExists");
                    }
                    existingClient.Name = clientModel.Name;
                    existingClient.Phone = clientModel.Phone;
                    existingClient.Address = clientModel.Address;
                    existingClient.Email = clientModel.Email;
                    existingClient.NIF = clientModel.NIF;
                    existingClient.IdentificationType = clientModel.IdentificationType;
                    existingClient.Login = clientModel.Login;
                    existingClient.Status = clientModel.Status;

                    _context.Update(existingClient);
                    await _context.SaveChangesAsync();                  
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientModelExists(clientModel.ClienteId))
                    {
                        ViewBag.Entity = "Client";
                        ViewBag.Controller = "Client";
                        ViewBag.Action = "Index";
                        return View("EntityNoLongerExists");
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("Successfully");               
            }
            return View(clientModel);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }

            var cliente = await _context.Client
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
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
            await _context.SaveChangesAsync();
            return View("DeletedSuccess");
        }
        private bool ClientModelExists(int id)
        {
            return _context.Client.Any(e => e.ClienteId == id);
        }

    }
}
