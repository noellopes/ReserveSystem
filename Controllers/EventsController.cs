using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ReserveSystem.Data;
using ReserveSystem.Models;
using static System.Reflection.Metadata.BlobBuilder;

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
        public async Task<IActionResult> Show(int page = 1, string searchName = "")
        {
            var eventsQuery = _context.Events.Where(e => e.inUse); // Apenas eventos ativos

            if (!string.IsNullOrEmpty(searchName))
            {
                eventsQuery = eventsQuery.Where(e => e.nameEv.Contains(searchName));
            }

            var totalItems = await eventsQuery.CountAsync();

            var events = await eventsQuery
                .OrderBy(e => e.nameEv)
                .Skip((page - 1) * 10)
                .Take(10)
                .ToListAsync();

            var model = new EventsViewModel
            {
                Events = events,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = totalItems,
                },
                SearchName = searchName
            };

            return View(model);
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
		public async Task<IActionResult> Create([Bind("event_id,nameEv,startDate,endDate,fee,anual,level,municipal,national,inUse")] Events events)
		{
            bool eventExists = await _context.Events.AnyAsync(e => (e.nameEv == events.nameEv)&&(e.inUse==true));
            if (eventExists)
            {
                ModelState.AddModelError("nameEv", "An event with this name already exists.");
            }

            if ((events.endDate - events.startDate).TotalDays > 7)
            {
                // Adiciona um erro ao ModelState se a validação falhar
                ModelState.AddModelError("endDate", "The date diference has to be a maximum of 1 week!");
            }

            if (ModelState.IsValid)
			{
				events.inUse = true;
				_context.Add(events);
				await _context.SaveChangesAsync();
				ViewBag.Entity = "Event";
				ViewBag.Controller = "Events";
				ViewBag.Action = "Details";
				ViewBag.Id = events.event_id;
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
                ViewBag.Action = "Details";
                ViewBag.Id = events.event_id;
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
                ViewBag.Action = "Details";
                ViewBag.Id = events.event_id;
                return View("EditSuccess");
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
				events.inUse = false;

				// Atualizar o evento no banco de dados
				_context.Update(events);
				await _context.SaveChangesAsync();
			}

			ViewBag.Entity = "Event";
			ViewBag.Controller = "Events";
			ViewBag.Action = "Show";
			return View("DeleteSuccess");
		}


		private bool EventsExists(int id)
        {
            return _context.Events.Any(e => e.event_id == id);
        }
    }
}
