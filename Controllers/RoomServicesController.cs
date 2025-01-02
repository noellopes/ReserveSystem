﻿using System;
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
        private readonly ReserveSystemContext _context;

        public RoomServicesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomServices
        public async Task<IActionResult> Index()
        {
            var reserveSystemContext = _context.RoomService.Include(r => r.Job);
            return View(await reserveSystemContext.ToListAsync());
        }

        // GET: RoomServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService
                .Include(r => r.Job)
                .FirstOrDefaultAsync(m => m.ID_Room_Service == id);
            if (roomService == null)
            {
                return NotFound();
            }

            return View(roomService);
        }

        // GET: RoomServices/Create
        public IActionResult Create()
        {
            ViewData["Job_ID"] = new SelectList(_context.Job, "Job_ID", "Job_ID");
            return View();
        }

        // POST: RoomServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Room_Service,Job_ID,Room_Service_Name,Room_Service_Description,Room_Service_Active")] RoomService roomService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Job_ID"] = new SelectList(_context.Job, "Job_ID", "Job_ID", roomService.Job_ID);
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
                return NotFound();
            }
            ViewData["Job_ID"] = new SelectList(_context.Job, "Job_ID", "Job_ID", roomService.Job_ID);
            return View(roomService);
        }

        // POST: RoomServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Room_Service,Job_ID,Room_Service_Name,Room_Service_Description,Room_Service_Active")] RoomService roomService)
        {
            if (id != roomService.ID_Room_Service)
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
                    if (!RoomServiceExists(roomService.ID_Room_Service))
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
            ViewData["Job_ID"] = new SelectList(_context.Job, "Job_ID", "Job_ID", roomService.Job_ID);
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
                .Include(r => r.Job)
                .FirstOrDefaultAsync(m => m.ID_Room_Service == id);
            if (roomService == null)
            {
                return NotFound();
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
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomServiceExists(int id)
        {
            return _context.RoomService.Any(e => e.ID_Room_Service == id);
        }
    }
}