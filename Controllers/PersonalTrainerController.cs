﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class PersonalTrainerController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public PersonalTrainerController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: PersonalTrainer/Index
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.PersonalTrainer.ToListAsync());
            }
            catch (Exception ex)
            {
                // Registre o erro
                Console.WriteLine(ex.Message);
                return View("Error"); // Certifique-se de ter uma View de erro.
            }
        }

        // GET: PersonalTrainer/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var trainer = _context.PersonalTrainer
                                  .FirstOrDefault(t => t.Id == id);

            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // GET: PersonalTrainer/Create
        public IActionResult Create()
        {
            // Passa uma nova instância do modelo para a view
            return View(new PersonalTrainerModel { Name = "", Email = ""});
        }

        // POST: PersonalTrainer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonalTrainerModel trainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainer);
                await _context.SaveChangesAsync();
                TempData["messageToast"] = "Personal Trainer criado com sucesso!";

                return RedirectToAction(nameof(Index));  // Redireciona para a Index após a criação
            }

            return View(trainer);
        }

        // GET: PersonalTrainer/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var trainer = _context.PersonalTrainer
                                  .FirstOrDefault(t => t.Id == id);

            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PersonalTrainerModel model, string[] specialties)
        {
            if (ModelState.IsValid)
            {
                // Atualiza as especialidades do Personal Trainer
                model.Specialties = specialties.Select(s => (TrainerSpecialty)Enum.Parse(typeof(TrainerSpecialty), s)).ToList();

                _context.Update(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: PersonalTrainer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.PersonalTrainer.FirstOrDefaultAsync(t => t.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: PersonalTrainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainer = await _context.PersonalTrainer.FindAsync(id);
            _context.PersonalTrainer.Remove(trainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(int id)
        {
            return _context.PersonalTrainer.Any(t => t.Id == id);
        }
    }
}
