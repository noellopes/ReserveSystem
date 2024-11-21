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
    public class EventsController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public EventsController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Show()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .FirstOrDefaultAsync(m => m.event_id == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("event_id,nameEv,startDate,endDate,fee,anual,level,municipal,national")] Events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                ViewBag.Entity = "Event";
                ViewBag.Controller = "Events";
                ViewBag.Action = "Show";
                return View("CreateSuccess");
            }
            return View(events);
        }

        // GET: Events/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                ViewBag.Entity = "Event";
                ViewBag.Controller = "Events";
                ViewBag.Action = "Show";
                return View("EntityNoLongerExists");
            }
            return View(events);
        }


        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("event_id,nameEv,startDate,endDate,fee,anual,level,municipal,national")] Events events)
        {
            if (id != events.event_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsExists(events.event_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Entity = "Event";
                ViewBag.Controller = "Events";
                ViewBag.Action = "Show";
                return View("DeleteSuccess");
            }
            return View(events);
        }


        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .FirstOrDefaultAsync(m => m.event_id == id);
            if (events == null)
            {
                ViewBag.Entity = "Event";
                ViewBag.Controller = "Events";
                ViewBag.Action = "Show";
                return View("DeleteSuccess");
            }

            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.Events.FindAsync(id);
            if (events != null)
            {
                _context.Events.Remove(events);
                await _context.SaveChangesAsync();
            }

            ViewBag.Entity = "Event";
            ViewBag.Controller = "Events";
            ViewBag.Action = "Show";
            return View("DeleteSuccess");

            
           // return RedirectToAction(nameof(Show)); // Redirect to Show page after deletion
        }

        private bool EventsExists(int id)
        {
            return _context.Events.Any(e => e.event_id == id);
        }
    }
}
