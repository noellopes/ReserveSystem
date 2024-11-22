using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ClientsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // Action to list clients with sorting and pagination
        public async Task<IActionResult> Index(int page = 1, string nameSearch = "")
        {
            int pageSize = 15;
            var clientsQuery = _context.Clients.AsQueryable();

            // Filtering clients by name
            if (!string.IsNullOrEmpty(nameSearch))
            {
                clientsQuery = clientsQuery.Where(c => c.ClientName.Contains(nameSearch));
            }

            // Calculate total clients and pages
            var totalClients = await clientsQuery.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalClients / pageSize);

            // Retrieve paginated clients
            var clients = await clientsQuery
                .OrderBy(c => c.ClientName) // Order by name
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Prepare the ViewModel for the View
            var model = new ClientViewModel
            {
                Clients = clients,
                CurrentPage = page,
                TotalPages = totalPages,
                SearchName = nameSearch
            };

            return View(model);
        }

        // Method to search clients by name (for autocomplete)
        [HttpGet]
        public async Task<IActionResult> SearchClientsByName(string name)
        {
            // Filter clients by partial name
            var clients = await _context.Clients
                .Where(c => c.ClientName.Contains(name))
                .Select(c => c.ClientName)
                .Take(10) // Limit to 10 results
                .ToListAsync();

            // Return the client names as JSON
            return Json(clients);
        }

        // Methods to show details, edit, create, and delete (already implemented correctly)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null) return NotFound();

            return View(client);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientName,ClientEmail,ClientAddress,ClientNIF,ClientPhone,ClientLogin,ClientStatus")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var client = await _context.Clients.FindAsync(id);
            if (client == null) return NotFound();
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,ClientName,ClientEmail,ClientAddress,ClientNIF,ClientPhone,ClientLogin,ClientStatus")] Client client)
        {
            if (id != client.ClientId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null) return NotFound();

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();

                // Armazena a mensagem de sucesso no TempData
                TempData["SuccessMessage"] = "Client successfully deleted.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id) => _context.Clients.Any(e => e.ClientId == id);
    }
}
