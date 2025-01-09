using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Controllers
{
    public class RoomServicePricesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomServicePricesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomServicePrices
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.RoomServicePrice.Include(r => r.RoomService);
            return View(await reserveSystemContext.ToListAsync());
        }

        public IActionResult Index(DateTime? searchStartDate, DateTime? searchEndDate, int? selectedRoomServiceId)
        {
            // Obtenha a lista inicial de RoomServicePrices
            var query = _context.RoomServicePrice.AsQueryable();

            // Aplicar filtro de data inicial, se fornecido
            if (searchStartDate.HasValue)
            {
                query = query.Where(r => r.Start_Date >= searchStartDate.Value);
            }

            // Aplicar filtro de data final, se fornecido
            if (searchEndDate.HasValue)
            {
                query = query.Where(r => r.End_Date <= searchEndDate.Value);
            }

            // Aplicar filtro pelo Nome do serviço de quarto, se fornecido
            if (selectedRoomServiceId.HasValue)
            {
                query = query.Where(r => r.ID_Room_Service == selectedRoomServiceId.Value);
            }

            // Obtenha a lista filtrada
            var roomServicePrices = query.ToList();

            // Obtenha a lista de RoomServices para o dropdown
            var roomServices = _context.RoomService
                .Select(rs => new SelectListItem
                {
                    Value = rs.ID_Room_Service.ToString(),
                    Text = rs.Room_Service_Name
                })
                .ToList();

            // Crie o ViewModel
            var viewModel = new RoomServicePriceViewModel
            {
                RoomServicePrices = roomServicePrices,
                RoomServices = new SelectList(roomServices, "Value", "Text"),
                SearchStartDate = searchStartDate,
                SearchEndDate = searchEndDate,
                SelectedRoomServiceId = selectedRoomServiceId
            };

            return View(viewModel);
        }


        // GET: RoomServicePrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServicePrice = await _context.RoomServicePrice
                .Include(r => r.RoomService)
                .FirstOrDefaultAsync(m => m.ID_Room_Service_Price == id);
            if (roomServicePrice == null)
            {
                return NotFound();
            }

            return View(roomServicePrice);
        }

        // GET: RoomServicePrices/Create
        public IActionResult Create()
        {
            ViewData["ID_Room_Service"] = new SelectList(_context.RoomService, "ID_Room_Service", "Room_Service_Name");
            return View();
        }

        // POST: RoomServicePrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Room_Service_Price,ID_Room_Service,Start_Date,End_Date,Room_Service_Price")] RoomServicePrice roomServicePrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomServicePrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Room_Service"] = new SelectList(_context.RoomService, "ID_Room_Service", "Room_Service_Name", roomServicePrice.ID_Room_Service);
            return View(roomServicePrice);
        }

        // GET: RoomServicePrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServicePrice = await _context.RoomServicePrice.FindAsync(id);
            if (roomServicePrice == null)
            {
                return NotFound();
            }
            ViewData["ID_Room_Service"] = new SelectList(_context.RoomService, "ID_Room_Service", "Room_Service_Name", roomServicePrice.ID_Room_Service);
            return View(roomServicePrice);
        }

        // POST: RoomServicePrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Room_Service_Price,ID_Room_Service,Start_Date,End_Date,Room_Service_Price")] RoomServicePrice roomServicePrice)
        {
            if (id != roomServicePrice.ID_Room_Service_Price)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomServicePrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServicePriceExists(roomServicePrice.ID_Room_Service_Price))
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
            ViewData["ID_Room_Service"] = new SelectList(_context.RoomService, "ID_Room_Service", "Room_Service_Name", roomServicePrice.ID_Room_Service);
            return View(roomServicePrice);
        }

        // GET: RoomServicePrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServicePrice = await _context.RoomServicePrice
                .Include(r => r.RoomService)
                .FirstOrDefaultAsync(m => m.ID_Room_Service_Price == id);
            if (roomServicePrice == null)
            {
                return NotFound();
            }

            return View(roomServicePrice);
        }

        // POST: RoomServicePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomServicePrice = await _context.RoomServicePrice.FindAsync(id);
            if (roomServicePrice != null)
            {
                _context.RoomServicePrice.Remove(roomServicePrice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomServicePriceExists(int id)
        {
            return _context.RoomServicePrice.Any(e => e.ID_Room_Service_Price == id);
        }
    }
}
