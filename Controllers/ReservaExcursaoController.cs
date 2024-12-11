using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using PagedList;

namespace ReserveSystem.Controllers
{
    public class ReservaExcursaoController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ReservaExcursaoController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ReservaExcursao
        public async Task<IActionResult> Index(string searchString, string filterBy, string sortOrder,int? page,string currentFilter )

        {
            Console.WriteLine($"filterBy: {filterBy}");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.FilterBy = filterBy ?? "titulo";
            ViewBag.SearchString = searchString;

            var reservas = from r in _context.ReservaExcursaoModel
                           .Include(r => r.Cliente)
                           .Include(r => r.Excursao)
                           select r;

            

            
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(filterBy))
            {
                
                switch (filterBy.ToLower())
                {
                    case "titulo":
                        reservas = reservas.Where(r => r.Excursao.Titulo.Contains(searchString));
                        break;
                    case "cliente":
                        reservas = reservas.Where(r => r.Cliente.Nome.Contains(searchString));
                        break;
                    case "data":
                        if (int.TryParse(searchString, out int searchNumber))
                        {
                            reservas = reservas.Where(r => r.DataReserva.Day == searchNumber ||
                                                           r.DataReserva.Month == searchNumber ||
                                                           r.DataReserva.Year.ToString().Contains(searchString));
                        }
                        break;



                    // Adicione mais casos conforme necessário
                    default:
                        break;
                }
            }
          

            switch (sortOrder)
            {
                case "Name_desc":
                    reservas = reservas.OrderByDescending(r => r.Cliente.Nome);
                    break;
                case "Date":
                    reservas=reservas.OrderBy(r=>r.DataReserva);
                    break;
                case "date_desc":
                    reservas = reservas.OrderByDescending(r => r.DataReserva);
                    break;

                
                default :
                    reservas = reservas.OrderBy(r => r.Cliente.Nome);
                    break;

            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(reservas.ToPagedList(pageNumber, pageSize));
            // return View(await reservas.ToListAsync());
        }


        // GET: ReservaExcursao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaExcursaoModel = await _context.ReservaExcursaoModel
                .Include(r => r.Cliente)
                .Include(r => r.Excursao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaExcursaoModel == null)
            {
                return NotFound();
            }

            return View(reservaExcursaoModel);
        }

        // GET: ReservaExcursao/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome");
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao");
            return View();
        }

        // POST: ReservaExcursao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ExcursaoId,DataReserva,NumPessoas")] ReservaExcursaoModel reservaExcursaoModel)
        {
            if (ModelState.IsValid)
            {
                var excursao = await _context.ExcursaoModel.FindAsync(reservaExcursaoModel.ExcursaoId);


                if (excursao == null) {
                    ModelState.AddModelError("ExcursaoId", "A excursão selecionada não existe.");
                    ViewBag.ClienteId = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome", reservaExcursaoModel.ClienteId);
                    ViewBag.ExcursaoId = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Titulo", reservaExcursaoModel.ExcursaoId);
                    return View(reservaExcursaoModel);

                }

                reservaExcursaoModel.ValorTotal = reservaExcursaoModel.NumPessoas * excursao.Preco;

                _context.Add(reservaExcursaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            

            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome", reservaExcursaoModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", reservaExcursaoModel.ExcursaoId);
            return View(reservaExcursaoModel);
        }

        // GET: ReservaExcursao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reservaExcursaoModel = await _context.ReservaExcursaoModel.FindAsync(id);
            
           
            if (reservaExcursaoModel == null)
            {
                return NotFound();
            }
            
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome", reservaExcursaoModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", reservaExcursaoModel.ExcursaoId);
            return View(reservaExcursaoModel);
        }

        // POST: ReservaExcursao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ExcursaoId,DataReserva,NumPessoas,ValorTotal")] ReservaExcursaoModel reservaExcursaoModel)
        {
            if (id != reservaExcursaoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var excursao = await _context.ExcursaoModel.FindAsync(reservaExcursaoModel.ExcursaoId);

                try
                {
                    reservaExcursaoModel.ValorTotal = reservaExcursaoModel.NumPessoas * excursao.Preco;
                    _context.Update(reservaExcursaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExcursaoModelExists(reservaExcursaoModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome", reservaExcursaoModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", reservaExcursaoModel.ExcursaoId);
            return View(reservaExcursaoModel);
        }

        // GET: ReservaExcursao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaExcursaoModel = await _context.ReservaExcursaoModel
                .Include(r => r.Cliente)
                .Include(r => r.Excursao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaExcursaoModel == null)
            {
                return NotFound();
            }

            return View(reservaExcursaoModel);
        }

        // POST: ReservaExcursao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaExcursaoModel = await _context.ReservaExcursaoModel.FindAsync(id);
            if (reservaExcursaoModel != null)
            {
                _context.ReservaExcursaoModel.Remove(reservaExcursaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExcursaoModelExists(int id)
        {
            return _context.ReservaExcursaoModel.Any(e => e.Id == id);
        }
    }
}
