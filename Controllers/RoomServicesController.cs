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
    public class RoomServicesController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public RoomServicesController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: RoomServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomService.ToListAsync());
        }

        // GET: RoomServices/Details/5
        public async Task<IActionResult> Details(int? id, bool savedNow = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService
                .FirstOrDefaultAsync(m => m.ID_RoomService == id);
            if (roomService == null)
            {
                ViewBag.Entity = "RoomService";
                ViewBag.Controller = "RoomServices";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }

            ViewBag.Saved = savedNow;
            return View(roomService);
        }

        // GET: RoomServices/Create
        public IActionResult Create(string? Name = null)
        {
            if (Name != null)
            {
                RoomService roomService = new RoomService
                {
                    Room_Service_Name = Name
                };

                ViewBag.PreviouslyDeleted = true;
                return View(roomService);
            }
            return View();
        }

        // POST: RoomServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_RoomService,Job_ID,Room_Service_Name,Room_Service_Description,Room_Service_Price,Room_Service_Active,Room_Service_Limit_Hour")] RoomService roomService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new {id = roomService.ID_RoomService, savedNow = true });
            }
            return View(roomService);
        }

        // GET: RoomServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService.FindAsync(id);
            if (roomService == null)
            {
                ViewBag.Entity = "RoomService";
                ViewBag.Controller = "RoomServices";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }
            return View(roomService);
        }

        // POST: RoomServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_RoomService,Job_ID,Room_Service_Name,Room_Service_Description,Room_Service_Price,Room_Service_Active,Room_Service_Limit_Hour")] RoomService roomService)
        {
            if (id != roomService.ID_RoomService)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServiceExists(roomService.ID_RoomService))
                    {
                        return RedirectToAction(nameof(Create), new { Name = roomService.Room_Service_Name });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = roomService.ID_RoomService, savedNow = true });
            }
            return View(roomService);
        }

        // GET: RoomServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService
                .FirstOrDefaultAsync(m => m.ID_RoomService == id);
            if (roomService == null)
            {
                ViewBag.Entity = "RoomService";
                ViewBag.Controller = "RoomServices";
                ViewBag.Action = "Index";
                return View("DeleteSuccess");
            }

            return View(roomService);
        }

        // POST: RoomServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomService = await _context.RoomService.FindAsync(id);
            if (roomService != null)
            {
                _context.RoomService.Remove(roomService);
                await _context.SaveChangesAsync(); // Salva as mudanças no banco
            }

            ViewBag.Entity = "RoomService";
            ViewBag.Controller = "RoomServices";
            ViewBag.Action = "Index";
            return View("DeleteSuccess");
        }

        private bool RoomServiceExists(int id)
        {
            return _context.RoomService.Any(e => e.ID_RoomService == id);
        }
    }
}
