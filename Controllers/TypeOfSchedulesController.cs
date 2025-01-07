﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TypeOfSchedulesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public TypeOfSchedulesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: TypeOfSchedules
        public async Task<IActionResult> Index(int page = 1, string searchTypeOfScheduleName = "", string searchTypeOfScheduleDescription = "")
        {
            int pageSize = 5;

            var query = _context.TypeOfSchedule.AsQueryable();

            // by name filter
            if (!string.IsNullOrEmpty(searchTypeOfScheduleName))
            {
                query = query.Where(t => t.TypeOfScheduleName.Contains(searchTypeOfScheduleName));
            }

            // by desc filter
            if (!string.IsNullOrEmpty(searchTypeOfScheduleDescription))
            {
                query = query.Where(t => t.TypeOfScheduleDescription.Contains(searchTypeOfScheduleDescription));
            }

            var totalItems = await query.CountAsync();

            // Criando e preenchendo o PagingInfo
            var pagingInfo = new PagingInfo
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = page
            };

            var items = await query
                .OrderBy(t => t.TypeOfScheduleName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new TypeOfScheduleViewModel
            {
                TypeOfSchedules = items,
                PagingInfo = pagingInfo,  // Passando o PagingInfo para o ViewModel
                SearchTypeOfScheduleName = searchTypeOfScheduleName,
                SearchTypeOfScheduleDescription = searchTypeOfScheduleDescription
            };

            return View(viewModel);
        }

        // GET: TypeOfSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfSchedule = await _context.TypeOfSchedule
                .FirstOrDefaultAsync(m => m.TypeOfScheduleId == id);
            if (typeOfSchedule == null)
            {
                return NotFound();
            }

            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfSchedule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfScheduleId,TypeOfScheduleName,TypeOfScheduleDescription")] TypeOfSchedule typeOfSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfSchedule);
                await _context.SaveChangesAsync();

                // redirect to registrationComplete, passing the id of TypeOfSchedules
                return RedirectToAction("RegistrationComplete", "TypeOfSchedules", new { typeOfScheduleId = typeOfSchedule.TypeOfScheduleId });
            }
            return View(typeOfSchedule);
        }

        public async Task<IActionResult> RegistrationComplete(int typeOfScheduleId)
        {
            var typeOfSchedule = await _context.TypeOfSchedule.FirstOrDefaultAsync(t => t.TypeOfScheduleId == typeOfScheduleId);
            if (typeOfSchedule == null)
            {
                return NotFound();
            }

            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfSchedule = await _context.TypeOfSchedule.FindAsync(id);
            if (typeOfSchedule == null)
            {
                return NotFound();
            }
            return View(typeOfSchedule);
        }

        // POST: TypeOfSchedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeOfScheduleId,TypeOfScheduleName,TypeOfScheduleDescription")] TypeOfSchedule typeOfSchedule)
        {
            if (id != typeOfSchedule.TypeOfScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfScheduleExists(typeOfSchedule.TypeOfScheduleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Redireciona para a página de sucesso passando o id do TypeOfSchedule
                return RedirectToAction("EditSuccess", new { typeOfScheduleId = typeOfSchedule.TypeOfScheduleId });
            }
            return View(typeOfSchedule);
        }

        public async Task<IActionResult> EditSuccess(int typeOfScheduleId)
        {
            var typeOfSchedule = await _context.TypeOfSchedule
                .FirstOrDefaultAsync(t => t.TypeOfScheduleId == typeOfScheduleId);

            if (typeOfSchedule == null)
            {
                return NotFound();
            }

            return View(typeOfSchedule);
        }

        // GET: TypeOfSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfSchedule = await _context.TypeOfSchedule
                .FirstOrDefaultAsync(m => m.TypeOfScheduleId == id);
            if (typeOfSchedule == null)
            {
                return NotFound();
            }

            return View(typeOfSchedule);
        }

        // POST: TypeOfSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfSchedule = await _context.TypeOfSchedule.FindAsync(id);
            if (typeOfSchedule != null)
            {
                _context.TypeOfSchedule.Remove(typeOfSchedule);
                await _context.SaveChangesAsync();
            }

            // Redireciona para a página de confirmação de exclusão
            return RedirectToAction("DeleteSuccess", new { typeOfScheduleName = typeOfSchedule?.TypeOfScheduleName });
        }

        // GET: TypeOfSchedules/DeleteSuccess
        public IActionResult DeleteSuccess(string typeOfScheduleName)
        {
            ViewBag.TypeOfScheduleName = typeOfScheduleName;
            return View();
        }

        private bool TypeOfScheduleExists(int id)
        {
            return _context.TypeOfSchedule.Any(e => e.TypeOfScheduleId == id);
        }
    }
}