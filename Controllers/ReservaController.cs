using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ReservaController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ReservaController
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reserva
                .Include(r => r.TipoReserva)
                .Include(r => r.Client)
                .Include(r => r.Equipamento)
               // .Include(r => r.Sala)

                .ToListAsync();
            return View(reservas);
        }

        // GET: Pesquisa de Reserva
        public IActionResult Search(string clientName)
        {

            if (string.IsNullOrEmpty(clientName))
            {
                return View();
            }
            var reserva = _context.Reserva
                .Where(r => r.Client.NomeCliente.Contains(clientName))
                .ToList();

            return View(reserva);
        }


        // GET: ReservaController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var reserva = await _context.Reserva
         .Include(r => r.TipoReserva)
         .Include(r => r.Client)
         .Include(r => r.Equipamento)
         //.Include(r => r.Sala)
         .FirstOrDefaultAsync(m => m.IdReserva == id);

            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // GET: ReservaController/Create
        public IActionResult Create()
        {
            PopulateViewData();
            return View();
        }

        // POST: ReservaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva model)
        {
            if (ModelState.IsValid)
            {
                model.DataReserva = DateTime.Now; 
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateViewData();
            return View(model);
        }

        // GET: ReservaController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Encontra a reserva com as dependências necessárias
            var reserva = await _context.Reserva
                                        .Include(r => r.TipoReserva)
                                        .Include(r => r.Client)
                                        .Include(r => r.Equipamento)
                                       // .Include(r => r.Sala)
                                        .FirstOrDefaultAsync(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound();
            }

            // Preenche as listas de seleção
            PopulateViewData();
            return View(reserva);
        }

        // POST: ReservaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdReserva,IdTipoReserva,ClientId,IdEquipamento,DataReserva,PrecoTotal,TotalParticipantes")] Reserva model)
        {
            if (id != model.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Reserva atualizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(model.IdReserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            PopulateViewData();
            return View(model);
        }

        // GET: ReservaController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var reserva = await _context.Reserva
                .Include(r => r.TipoReserva)
                .Include(r => r.Client)
                 .Include(r => r.Equipamento)
                 //.Include(r => r.Sala)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: ReservaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateViewData()
        {

            var tipoReservaList = _context.TipoReserva
                .Select(tr => new SelectListItem
                {
                    Value = tr.idTipoReserva.ToString(),
                    Text = tr.NomeReserva
                }).ToList();

            tipoReservaList.Insert(0, new SelectListItem { Value = "", Text = "-- Choose Reservation -- " });
            ViewData["TipoReserva"] = tipoReservaList;


            var clientList = _context.ClientModel
                .Select(c => new SelectListItem
                {
                    Value = c.ClienteId.ToString(),
                    Text = c.NomeCliente
                }).ToList();

            clientList.Insert(0, new SelectListItem { Value = "", Text = "-- Choose Client -- " });
            ViewData["ClientId"] = clientList;


            var equipamentoList = _context.Equipamento
                .Select(te => new SelectListItem
                {
                    Value = te.IdEquipamento.ToString(),
                    Text = te.NomeEquipamento
                }).ToList();

            equipamentoList.Insert(0, new SelectListItem { Value = "", Text = "-- Choose Equipment -- " });
            ViewData["TipoEquipamento"] = equipamentoList;


            var salaList = _context.Sala
                .Include(s => s.TipoSala) // Inclui os dados do TipoSala
                .Select(s => new SelectListItem
                {
                    Value = s.IdSala.ToString(), // ID da Sala como valor
                    Text = s.TipoSala.NomeSala // Nome do Tipo de Sala como texto
                }).ToList();

            salaList.Insert(0, new SelectListItem { Value = "", Text = "-- Choose Room --" });
            ViewData["SalaId"] = salaList;
        }

        private bool ReservaExists(long id)
        {
            return _context.Reserva.Any(e => e.IdReserva == id);
        }



    }
}

