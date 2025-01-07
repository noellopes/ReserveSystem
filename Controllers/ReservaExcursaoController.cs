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
    public class ReservaExcursaoController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ReservaExcursaoController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ReservaExcursao
        public async Task<IActionResult> Index(
            string searchString,
            string filterBy,
            string sortOrder,
            int page = 1,
            int pageSize = 9)
        {
            // Parâmetros de ordenação
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            // Query inicial
            var query = _context.ReservaExcursaoModel
                .Include(r => r.Cliente)
                .Include(r => r.Excursao)
                .AsQueryable();

            // Filtragem
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(filterBy))
            {
                switch (filterBy.ToLower())
                {
                    case "titulo":
                        query = query.Where(r => r.Excursao.Titulo.Contains(searchString));
                        break;
                    case "cliente":
                        query = query.Where(r => r.Cliente.Nome.Contains(searchString));
                        break;
                    case "data":
                        if (DateTime.TryParse(searchString, out DateTime searchDate))
                        {
                            query = query.Where(r => r.DataReserva.Date == searchDate.Date);
                        }
                        break;
                }
            }

            // Ordenação
            switch (sortOrder)
            {
                case "Name_desc":
                    query = query.OrderByDescending(r => r.Cliente.Nome);
                    break;
                case "Date":
                    query = query.OrderBy(r => r.DataReserva);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(r => r.DataReserva);
                    break;
                default:
                    query = query.OrderBy(r => r.Cliente.Nome);
                    break;
            }

            // Contagem total para paginação
            int totalItems = await query.CountAsync();

            // Paginação
            var reservas = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Configurando ViewModel
            var viewModel = new ReservaExcursaoViewModel
            {
                Reservas = reservas,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = totalItems
                },
                SearchTitulo = filterBy == "titulo" ? searchString : string.Empty,
                SearchCliente = filterBy == "cliente" ? searchString : string.Empty
            };

            return View(viewModel);
        }

        // GET: ReservaExcursao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var reservaExcursaoModel = await _context.ReservaExcursaoModel
                .Include(r => r.Cliente)
                .Include(r => r.Excursao)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reservaExcursaoModel == null) return NotFound();

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ExcursaoId,DataReserva,NumPessoas")] ReservaExcursaoModel reservaExcursaoModel)
        {
            if (ModelState.IsValid)
            {
                var excursao = await _context.ExcursaoModel.FindAsync(reservaExcursaoModel.ExcursaoId);

                if (excursao == null)
                {
                    ModelState.AddModelError("ExcursaoId", "A excursão selecionada não existe.");
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
            if (id == null) return NotFound();

            var reservaExcursaoModel = await _context.ReservaExcursaoModel.FindAsync(id);
            if (reservaExcursaoModel == null) return NotFound();

            ViewData["ClienteId"] = new SelectList(_context.ClienteTestModel, "ClienteId", "Nome", reservaExcursaoModel.ClienteId);
            ViewData["ExcursaoId"] = new SelectList(_context.ExcursaoModel, "Excursao_Id", "Descricao", reservaExcursaoModel.ExcursaoId);
            return View(reservaExcursaoModel);
        }

        // POST: ReservaExcursao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ExcursaoId,DataReserva,NumPessoas,ValorTotal")] ReservaExcursaoModel reservaExcursaoModel)
        {
            if (id != reservaExcursaoModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var excursao = await _context.ExcursaoModel.FindAsync(reservaExcursaoModel.ExcursaoId);

                reservaExcursaoModel.ValorTotal = reservaExcursaoModel.NumPessoas * excursao.Preco;
                _context.Update(reservaExcursaoModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(reservaExcursaoModel);
        }

        private bool ReservaExcursaoModelExists(int id)
        {
            return _context.ReservaExcursaoModel.Any(e => e.Id == id);
        }
    }
}
