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
    public class ClientController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ClientController(ReserveSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.ClientModel.Any())
            {
                var listaClientes = new List<ClientModel>
        {
            new ClientModel {NomeCliente = "João Silva", MoradaCliente = "Rua das Flores, 123", Email = "joao.silva@example.com", Password = "senha123", Telefone = "912345678", NIF = 123456789 },
            new ClientModel {NomeCliente = "Maria Oliveira", MoradaCliente = "Avenida Central, 456", Email = "maria.oliveira@example.com", Password = "senha456", Telefone = "923456789", NIF = 234567890 },
            new ClientModel{NomeCliente = "Carlos Souza", MoradaCliente = "Praça da Liberdade, 789", Email = "carlos.souza@example.com", Password = "senha789", Telefone = "934567890", NIF = 345678901 },
            new ClientModel {NomeCliente = "Ana Santos", MoradaCliente = "Rua das Palmeiras, 101", Email = "ana.santos@example.com", Password = "senha101", Telefone = "945678901", NIF = 456789012 },
            new ClientModel {NomeCliente = "Pedro Lima", MoradaCliente = "Estrada Velha, 202", Email = "pedro.lima@example.com", Password = "senha202", Telefone = "956789012", NIF = 567890123 },
            new ClientModel {NomeCliente = "Fernanda Costa", MoradaCliente = "Travessa do Sol, 303", Email = "fernanda.costa@example.com", Password = "senha303", Telefone = "967890123", NIF = 678901234 },
            new ClientModel {NomeCliente = "Rafael Nascimento", MoradaCliente = "Largo do Mercado, 404", Email = "rafael.nascimento@example.com", Password = "senha404", Telefone = "978901234", NIF = 789012345 },
            new ClientModel {NomeCliente = "Juliana Alves", MoradaCliente = "Bairro da Paz, 505", Email = "juliana.alves@example.com", Password = "senha505", Telefone = "989012345", NIF = 890123456 },
            new ClientModel {NomeCliente = "Bruno Pereira", MoradaCliente = "Rua Nova, 606", Email = "bruno.pereira@example.com", Password = "senha606", Telefone = "991234567", NIF = 901234567 },
            new ClientModel {NomeCliente = "Patrícia Fernandes", MoradaCliente = "Vila Bela, 707", Email = "patricia.fernandes@example.com", Password = "senha707", Telefone = "992345678", NIF = 012345678 }
        };

                _context.ClientModel.AddRange(listaClientes);
                _context.SaveChanges();
            }

            var clientes = _context.ClientModel.ToList();
            return View(clientes);
        }


        

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel
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
        public async Task<IActionResult> Create([Bind("ClienteId,NomeCliente,MoradaCliente,Email,Password,Telefone,NIF")] ClientModel clientModel)
        {
            //try
            //{

            //}catch(Exception ex)
            //{

            //}
            if (ModelState.IsValid)
            {
                _context.Add(clientModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientModel);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }
            return View(clientModel);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,NomeCliente,MoradaCliente,Email,Password,Telefone,NIF")] ClientModel clientModel)
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
                return NotFound();
            }

            var clientModel = await _context.ClientModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel != null)
            {
                _context.ClientModel.Remove(clientModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientModelExists(int id)
        {
            return _context.ClientModel.Any(e => e.ClienteId == id);
        }
    }
}
