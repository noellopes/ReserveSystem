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
    public class ClienteTestController : Controller
    {
        private readonly ReserveSystemContext _context;

        public ClienteTestController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: ClienteTest
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteTestModel.ToListAsync());
        }

        // GET: ClienteTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTestModel = await _context.ClienteTestModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteTestModel == null)
            {
                return NotFound();
            }

            return View(clienteTestModel);
        }

        // GET: ClienteTest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nome,Email,Telefone,DataNascimento")] ClienteTestModel clienteTestModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteTestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteTestModel);
        }

        // GET: ClienteTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTestModel = await _context.ClienteTestModel.FindAsync(id);
            if (clienteTestModel == null)
            {
                return NotFound();
            }
            return View(clienteTestModel);
        }

        // POST: ClienteTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,Email,Telefone,DataNascimento")] ClienteTestModel clienteTestModel)
        {
            if (id != clienteTestModel.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteTestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteTestModelExists(clienteTestModel.ClienteId))
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
            return View(clienteTestModel);
        }

        // GET: ClienteTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteTestModel = await _context.ClienteTestModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteTestModel == null)
            {
                return NotFound();
            }

            return View(clienteTestModel);
        }

        // POST: ClienteTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteTestModel = await _context.ClienteTestModel.FindAsync(id);
            if (clienteTestModel != null)
            {
                _context.ClienteTestModel.Remove(clienteTestModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteTestModelExists(int id)
        {
            return _context.ClienteTestModel.Any(e => e.ClienteId == id);
        }
    }
}
