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

        public async Task<IActionResult> Index(string pesquisarEmail="", string pesquisarNIF="", int pagina=1)
        {
            var client = from c in _context.ClientModel.Include(c => c.Reserva)
                         select c;

            if (pesquisarEmail != "")
            {
                client = from c in client
                         where c.Email.Contains(pesquisarEmail)
                         select c;
            }
            if (pesquisarNIF != "")
            {
                client = from c in client
                         where c.NIF.ToString().Contains(pesquisarNIF)
                         select c;
            }

            var model = new ClientViewModel();

            model.paginacao = new Paginacao
            {
                PaginaCorrente = pagina,
                ItemTotal = await client.CountAsync(),
            };

            model.ClientModels = await client
                .OrderBy(c => c.NomeCliente)
                .Skip((model.paginacao.PaginaCorrente - 1) * model.paginacao.PaginaCorrente)
                .Take(model.paginacao.TamanhoPagina)
                .ToListAsync();

            model.PesquisarEmail = pesquisarEmail;
            model.PesquisarNIF = pesquisarNIF;

            try
            {
                var clientes = _context.ClientModel.ToList();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "An unexpected error occurred while fetching the client list.";
                return View(new List<ClientModel>());
            }

            return View(model);
        }

        

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntidadeNaoExiste");
            }

            var clientModel = await _context.ClientModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientModel == null)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntidadeNaoExiste");
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
                try
                {
                    var TelefoneExistente = await _context.ClientModel.FirstOrDefaultAsync(t => t.Telefone == clientModel.Telefone);
                    if(TelefoneExistente != null)
                    {
                        ModelState.AddModelError("Telefone", "Telefone Invalido. Por favor verifique e tente novamente!");
                        return View(clientModel);
                    }


                    var EmailExistente = await _context.ClientModel.FirstOrDefaultAsync(t => t.Email == clientModel.Email);
                    if (EmailExistente != null)
                    {
                        ModelState.AddModelError("Email", "Email Invalido. Por favor verifique e tente novamente!");
                        return View(clientModel);
                    }

                    if (!ValidadorNIF.NIFValido(clientModel.NIF))
                    {
                        ModelState.AddModelError("NIF", "NIF invalido");
                        return View(clientModel);

                    }
                    var NIFExistente = await _context.ClientModel.AnyAsync(c => c.NIF == clientModel.NIF);
                    if (NIFExistente)
                    {
                        ModelState.AddModelError("NIF", "NIF Errado");
                        return View(clientModel);
                    }
                    _context.Add(clientModel);
                    TempData["MensagemSucesso"] = "O Cliente foi adicionado com sucesso!";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erro : {ex.Message}");
                }
            }
            return View(clientModel);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntidadeNaoExiste");
            }

            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel == null)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntidadeNaoExiste");
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
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntidadeNaoExiste");

            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ClienteExistente = await _context.ClientModel.FindAsync(id);
                    if (ClienteExistente == null)
                    {
                        ViewBag.Entity = "Client";
                        ViewBag.Controller = "Client";
                        ViewBag.Action = "Index";
                        return View("EntidadeNaoExiste");

                    }
                    ClienteExistente.NomeCliente = clientModel.NomeCliente;
                    ClienteExistente.MoradaCliente = clientModel.MoradaCliente;
                    ClienteExistente.Email = clientModel.Email;
                    ClienteExistente.Password = clientModel.Password;
                    ClienteExistente.Telefone = clientModel.Telefone;
                    ClienteExistente.NIF = clientModel.NIF;

                    _context.Update(ClienteExistente);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientModelExists(clientModel.ClienteId))
                    {
                        //entity nao existe
                        ViewBag.Entity = "Client";
                        ViewBag.Controller = "Client";
                        ViewBag.Action = "Index";
                        return View("EntidadeNaoExiste");
                       
                    }
                    else
                    {

                        throw;
                    }
                }
                //updated successfullyy
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("updatedSuccessfully");
                
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
                return View("EntidadeNaoExiste");
            }

            var clientModel = await _context.ClientModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientModel == null)
            {
                ViewBag.Entity = "Client";
                ViewBag.Controller = "Client";
                ViewBag.Action = "Index";
                return View("EntidadeNaoExiste");
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
            ViewBag.Entity = "Client";
            ViewBag.Controller = "Client";
            ViewBag.Action = "Index";
            await _context.SaveChangesAsync();
            return View("succesfullyDeleted");

            
            //return RedirectToAction(nameof(Index));
        }

        private bool ClientModelExists(int id)
        {
            return _context.ClientModel.Any(e => e.ClienteId == id);
        }
    }
}
