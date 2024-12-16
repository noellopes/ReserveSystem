﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public ReservaController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutSchedule/Index
        public async Task<IActionResult> Index()
        {
            var schedules = _context.Reserva
                .Include(ws => ws.PersonalTrainer)
                .Include(ws => ws.Client);
            return View(await schedules.ToListAsync());
        }

        // GET: WorkoutSchedule/Create
        public async Task<IActionResult> Create()
        {
            // Carrega Personal Trainers e Clientes
            ViewData["Spaces"] = await _context.Spaces.ToListAsync() ?? new List<SpaceModel>();
            ViewData["PersonalTrainers"] = await _context.PersonalTrainer.ToListAsync() ?? new List<PersonalTrainerModel>();
            ViewData["Clients"] = await _context.Client.ToListAsync() ?? new List<ClientModel>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservaModel reserva)
        {
            // Verificar se a data é válida
            if (reserva.ReservationDate < DateTime.Today)
            {
                ModelState.AddModelError("ReservationDate", "A data da reserva não pode ser no passado.");
            }

            // Verificar se o horário final é maior que o inicial
            if (reserva.StartTime >= reserva.EndTime)
            {
                ModelState.AddModelError("EndTime", "O horário de término deve ser após o horário de início.");
            }

            // Verificar o intervalo mínimo de 30 minutos
            if ((reserva.EndTime - reserva.StartTime).TotalMinutes < 30)
            {
                ModelState.AddModelError("EndTime", "O intervalo mínimo entre os horários deve ser de 30 minutos.");
            }

            // Retorna à view se houver erros de validação
            if (!ModelState.IsValid)
            {
                // Recarregar listas de espaços, personal trainers e clientes para a view
                ViewData["Spaces"] = _context.Spaces.ToList();
                ViewData["PersonalTrainers"] = _context.PersonalTrainer.ToList();
                ViewData["Clients"] = _context.Client.ToList();
                return View(reserva);
            }

            // Salvar a reserva
            _context.Reserva.Add(reserva);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        // GET: WorkoutSchedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Reserva
                .Include(ws => ws.PersonalTrainer)
                .Include(ws => ws.Client)
                .FirstOrDefaultAsync(ws => ws.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: WorkoutSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
