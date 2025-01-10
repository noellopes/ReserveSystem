using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace ReserveSystem.Controllers
{
    [Authorize(Roles = "admin")] //futuramente , quando juntarmos apenas o staff pode aceder a este controller
    public class RoomTypesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomTypesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomTypes
        public async Task<IActionResult> Index(int page = 1, string searchQuery = "")
        {
            // Define o tamanho da página
            var pageSize = 9;

            // Cria a consulta inicial
            var roomTypes = from rt in _context.RoomType
                            select rt;

            // Aplica o filtro de busca, se houver
            if (!string.IsNullOrEmpty(searchQuery))
            {
                roomTypes = roomTypes.Where(rt => rt.Type.Contains(searchQuery) || rt.RoomTypeId.ToString().Contains(searchQuery));
            }

            // Passa o valor de busca para a ViewData para manter o valor no campo de busca
            ViewData["SearchQuery"] = searchQuery;

            // Calcula o número total de itens
            var totalItems = await roomTypes.CountAsync();

            // Calcula o número total de páginas
            var totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);

            // Verifica se a página solicitada é válida
            page = Math.Max(page, 1);
            if (page > totalPages && totalPages > 0)  page = totalPages; // Ajusta a página para o máximo permitido
            

            // Obtém os itens da página atual
            var roomTypesPaged = await roomTypes
                .OrderBy(rt => rt.Type)  // Ordena por tipo ou outro critério
                .Skip((page - 1) * pageSize)  // Pula as páginas anteriores
                .Take(pageSize)  // Pega o número de itens correspondente ao tamanho da página
                .ToListAsync();

            // Passa as informações de paginação para a ViewData
            ViewData["TotalItems"] = totalItems;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            // Retorna os dados para a view
            return View(roomTypesPaged);
        }

        // GET: RoomTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (roomType == null)
            {

                ViewBag.Entity = "RoomTypes";
                ViewBag.Controller = "RoomTypes";
                ViewBag.Action = "Index";
                    return View("EntityNoLongerExists");   
            }
            return View(roomType);
        }

        // GET: RoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                // Adiciona o RoomType ao banco
                _context.RoomType.Add(roomType);
                await _context.SaveChangesAsync();

                // Associa um quarto automaticamente ao RoomTypeId recém-criado
                for(int i = 0; i <= 3; i++)
                {
                    var room = new Room
                    {
                        RoomTypeId = roomType.RoomTypeId
                    };
                    _context.Room.Add(room);
                }
                


                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Room Type created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(roomType);
        }

        // GET: RoomTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType == null)
            {

                ViewBag.Entity = "RoomTypes";
                ViewBag.Controller = "RoomTypes";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }


            return View(roomType);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomTypeId,HasView,Type,RoomCapacity,Beds,AcessibilityRoom")] RoomType roomType)
        {
          
            if (roomType == null)
            {

                ViewBag.Entity = "RoomTypes";
                ViewBag.Controller = "RoomTypes";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomType);
                    await _context.SaveChangesAsync();
                    

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomTypeExists(roomType.RoomTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Entity = "RoomTypes";
                ViewBag.Controller = "RoomTypes";
                ViewBag.Action = "Index";
                return View("Successfully");
                
            }
            return View(roomType);
        }

        // GET: RoomTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType
                .FirstOrDefaultAsync(m => m.RoomTypeId == id);
            

            return View(roomType);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType != null)
            {

                _context.RoomType.Remove(roomType);
                
            }
            ViewBag.Entity = "RoomTypes";
            ViewBag.Controller = "RoomTypes";
            ViewBag.Action = "Index";
            
            await _context.SaveChangesAsync();
            return View("DeletedSuccess");
           
        }

        private bool RoomTypeExists(int id)
        {
            return _context.RoomType.Any(e => e.RoomTypeId == id);
        }
    }
}
