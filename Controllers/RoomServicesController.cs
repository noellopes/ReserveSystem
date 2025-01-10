
//using System;
//using System.Linq;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using ReserveSystem.Data;
//using ReserveSystem.Models;
//using ReserveSystem.ViewModels;
//using System.Diagnostics;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace ReserveSystem.Controllers
//{
//    public class RoomServiceController : Controller
//    {
//        private readonly ReserveSystemContext _context;

//        public RoomServiceController(ReserveSystemContext context)
//        {
//            _context = context;
//        }

//        // GET: RoomServiceBooking
//        public async Task<IActionResult> Index(int jobId = 0, int roomServiceId = 0, int page = 1, string searchName = "")
//        {
//            if (_context.RoomService == null)
//            {
//                return Problem("Entity set 'ReserveSystemContext.RoomService' is null.");
//            }

//            var roomServices = from rs in _context.RoomService
//                        .Include(rs => rs.Job)
//                           select rs;

//            if (jobId != 0)
//            {
//                roomServices = roomServices.Where(rs => rs.Job_ID == jobId);
//            }

//            if (!string.IsNullOrEmpty(searchName))
//            {
//                roomServices = roomServices.Where(rs => rs.Room_Service_Name.Contains(searchName));
//            }


//            var model = new RoomServiceViewModel
//            {
//                ID_Room_Service = roomServiceId, // Preserve room service filter
//                Job_ID = jobId,         // Preserve search filter
//                PagingInfo = new PagingInfo
//                {
//                    CurrentPage = page,
//                    TotalItems = await roomServices.CountAsync()
//                },
//                // Get jobs for dropdown
//                Jobs = new SelectList(
//                    await _context.Job
//                        .OrderBy(j => j.Job_Name)
//                        .ToListAsync(),
//                    "Id",
//                    "Name",
//                    jobId  // Set selected value
//                )
//            };

//            // Get paginated results
//            var roomServiceList = await roomServices
//                .OrderBy(rs => rs.ID_Room_Service)
//                .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.PageSize)
//                .Take(model.PagingInfo.PageSize)
//                .ToListAsync();

//            model.RoomServices = roomServiceList;

//            return View(model);
//        }

//        // GET: RoomServiceBooking/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            var roomService = await _context.RoomService
//                .Include(rs => rs.Job)
//                .FirstOrDefaultAsync(m => m.ID_Room_Service == id);

//            if (roomService == null)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            return View(roomService);
//        }

//        // GET: RoomServiceBooking/Create
//        public async Task<IActionResult> Create()
//        {

//            // Populate select lists
//            await PopulateSelectLists();

//            return View();
//        }

//        // POST: RoomServiceBooking/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID_Room_Service, Room_Service_Name, Room_Service_Description, Room_Service_Active")] RoomService roomService)
//        {

//            if (ModelState.IsValid)
//            {
//                // Instead of saving directly, show confirmation
//                ViewBag.Action = "Create";
//                return View("ConfirmAction", roomService);
//            }

//            // If we got this far, something failed, redisplay form
//            await PopulateSelectLists();
//            return View(roomService);
//        }

//        // Add a new action to handle the confirmed create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> ConfirmCreate([Bind("ID_Room_Service, Room_Service_Name, Room_Service_Description, Room_Service_Active")] RoomService roomService)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(roomService);
//                await _context.SaveChangesAsync();
//                ViewBag.Action = "Create";
//                return View("ActionSuccess");
//            }
//            return View("Create", roomService);
//        }

//        // GET: RoomServiceBooking/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            // Include related entities when loading the services
//            var roomService = await _context.RoomService
//                .Include(rs => rs.Job)
//                .FirstOrDefaultAsync(rs => rs.ID_Room_Service == id);

//            if (roomService == null)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            // Populate select lists
//            await PopulateSelectLists();

//            // Pass the existing data to the view
//            ViewBag.RoomServiceName = roomService.Room_Service_Name;
//            ViewBag.RoomServiceDescription = roomService.Room_Service_Description;
//            ViewBag.RoomServiceActive = roomService.Room_Service_Active;


//            return View(roomService);
//        }

//        // POST: RoomServiceBooking/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(int id, [Bind("ID_Room_Service, Room_Service_Name, Room_Service_Description, Room_Service_Active")] RoomService roomService)
//        {
//            if (id != roomService.ID_Room_Service)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            if (ModelState.IsValid)
//            {
//                ViewBag.Action = "Edit";
//                return View("ConfirmAction", roomService);
//            }
//            return View(roomService);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> ConfirmEdit(int id, [Bind("ID_Room_Service, Room_Service_Name, Room_Service_Description, Room_Service_Active")] RoomService roomService)
//        {
//            if (id != roomService.ID_Room_Service)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(roomService);
//                    await _context.SaveChangesAsync();
//                    ViewBag.Action = "Edit";
//                    return View("ActionSuccess");
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!RoomServiceExists(roomService.ID_Room_Service))
//                    {
//                        return RedirectToAction(nameof(Error));
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//            }
//            return View("Edit", roomService);
//        }

//        // GET: RoomServiceBooking/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            var roomService = await _context.RoomService
//                .Include(rs => rs.Job)
//                .FirstOrDefaultAsync(m => m.ID_Room_Service == id);

//            if (roomService == null)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            return View(roomService);
//        }

//        // POST: RoomServiceBooking/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult Delete(int id)
//        {
//            var roomService = _context.RoomService.Find(id);
//            if (roomService == null)
//            {
//                return RedirectToAction(nameof(Error));
//            }

//            ViewBag.Action = "Delete";
//            return View("ConfirmAction", roomService);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> ConfirmDelete(int id)
//        {
//            var roomService = await _context.RoomService.FindAsync(id);
//            if (roomService != null)
//            {
//                _context.RoomService.Remove(roomService);
//                await _context.SaveChangesAsync();
//                ViewBag.Action = "Delete";
//                return View("ActionSuccess");
//            }

//            return RedirectToAction(nameof(Error));
//        }

//        private bool RoomServiceExists(int id)
//        {
//            return _context.RoomService.Any(e => e.ID_Room_Service == id);
//        }

//        // Helper method to populate select lists
//        private async Task PopulateSelectLists()
//        {
//            ViewBag.RoomServices = new SelectList(await _context.RoomService
//                .Where(rs => rs.Room_Service_Active)
//                .OrderBy(rs => rs.Room_Service_Name)
//                .Distinct()
//                .ToListAsync(), "Id", "Name");

//            ViewBag.Jobs = new SelectList(await _context.Job
//                .OrderBy(j => j.Job_Name)
//                .Distinct()
//                .ToListAsync(), "Id", "Name");

//        }



//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error(int? statusCode = null)
//        {
//            var error = new ErrorViewModel
//            {
//                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
//            };

//            // Default error message
//            ViewBag.ErrorMessage = "An error occurred while processing your request.";

//            if (statusCode.HasValue)
//            {
//                switch (statusCode.Value)
//                {
//                    case 404:
//                        ViewBag.ErrorMessage = "The requested page was not found.";
//                        break;
//                    case 500:
//                        ViewBag.ErrorMessage = "An internal server error occurred.";
//                        break;
//                    default:
//                        ViewBag.ErrorMessage = "An error occurred while processing your request.";
//                        break;
//                }
//            }

//            return View(error);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using ReserveSystem.Data;
//using ReserveSystem.Models;
//using ReserveSystem.ViewModels;

//namespace ReserveSystem.Controllers
//{
//    public class RoomServicesController : Controller
//    {
//        private readonly ReserveSystemContext _context;

//        public RoomServicesController(ReserveSystemContext context)
//        {
//            _context = context;
//        }

//        // GET: RoomServices
//        public async Task<IActionResult> Index()
//        {
//            var reserveSystemContext = _context.RoomService.Include(r => r.Job);
//            return View(await reserveSystemContext.ToListAsync());
//        }

//        public IActionResult Index(int? jobId, int page = 1)
//        {
//            // Obtenha a lista inicial de Jobs
//            var query = _context.Job.AsQueryable();

//            // Filtro pelo ID do Job, se fornecido
//            if (jobId.HasValue)
//            {
//                query = query.Where(j => j.Job_ID == jobId.Value);
//            }

//            // Obtenha a lista filtrada e ordenada
//            var jobs = query.ToList();

//            // Obtenha a lista de Jobs para o dropdown
//            var jobList = _context.Job
//                .Select(j => new SelectListItem
//                {
//                    Value = j.Job_ID.ToString(),
//                    Text = j.Job_Name // Propriedade do nome do trabalho
//                })
//                .ToList();

//            // Crie o ViewModel
//            var viewModel = new JobViewModel
//            {
//                Jobs = jobs,
//                JobIds = new SelectList(jobList, "Value", "Text"),
//                Job_ID = jobId
//            };

//            return View(viewModel);
//        }


//        // GET: RoomServices/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var roomService = await _context.RoomService
//                .Include(r => r.Job)
//                .FirstOrDefaultAsync(m => m.ID_Room_Service == id);
//            if (roomService == null)
//            {
//                return NotFound();
//            }

//            return View(roomService);
//        }

//        // GET: RoomServices/Create
//        public IActionResult Create()
//        {
//            ViewData["Job_ID"] = new SelectList(_context.Job, "Job_ID", "Job_ID");
//            return View();
//        }

//        // POST: RoomServices/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID_Room_Service,Job_ID,Room_Service_Name,Room_Service_Description,Room_Service_Active")] RoomService roomService)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(roomService);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["Job_ID"] = new SelectList(_context.Job, "Job_ID", "Job_ID", roomService.Job_ID);
//            return View(roomService);
//        }

//        // GET: RoomServices/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var roomService = await _context.RoomService.FindAsync(id);
//            if (roomService == null)
//            {
//                return NotFound();
//            }
//            ViewData["Job_ID"] = new SelectList(_context.Job, "Job_ID", "Job_ID", roomService.Job_ID);
//            return View(roomService);
//        }

//        // POST: RoomServices/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID_Room_Service,Job_ID,Room_Service_Name,Room_Service_Description,Room_Service_Active")] RoomService roomService)
//        {
//            if (id != roomService.ID_Room_Service)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(roomService);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!RoomServiceExists(roomService.ID_Room_Service))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["Job_ID"] = new SelectList(_context.Job, "Job_ID", "Job_ID", roomService.Job_ID);
//            return View(roomService);
//        }

//        // GET: RoomServices/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var roomService = await _context.RoomService
//                .Include(rs => rs.Job)
//                .FirstOrDefaultAsync(m => m.ID_Room_Service == id);
//            if (roomService == null)
//            {
//                return NotFound();
//            }

//            return View(roomService);
//        }

//        // POST: RoomServices/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var roomService = await _context.RoomService.FindAsync(id);
//            if (roomService != null)
//            {
//                _context.RoomService.Remove(roomService);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool RoomServiceExists(int id)
//        {
//            return _context.RoomService.Any(e => e.ID_Room_Service == id);
//        }
//    }
//}

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
    public class RoomServicesController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomServicesController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomServices
        public async Task<IActionResult> Index(string searchName, int? jobId, int page = 1)
        {
            // Obter todos os tipos de serviço para o filtro
            var jobs = await _context.Job.ToListAsync();
            var jobSelectList = new SelectList(jobs, "Job_ID", "Job_Name");

            // Filtrar os serviços de quarto
            var query = _context.RoomService.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(rs => rs.Room_Service_Name.Contains(searchName));
            }

            if (jobId.HasValue)
            {
                query = query.Where(rs => rs.Job_ID == jobId);
            }

            var roomServices = await query.ToListAsync();

            var viewModel = new RoomServiceViewModel
            {
                RoomServices = roomServices,
                Jobs = jobSelectList,
                SearchName = searchName,
                Job_ID = jobId,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = roomServices.Count
                }
            };

            return View(viewModel);
        }

        // GET: RoomServices/Details/5
        public async Task<IActionResult> Details(int? id, bool savedNow = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService
                .Include(rs => rs.Job)
                .FirstOrDefaultAsync(m => m.ID_Room_Service == id);

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
        public IActionResult Create()
        {
            var jobs = _context.Job
                .Select(j => new SelectListItem
                {
                    Value = j.Job_ID.ToString(),
                    Text = j.Job_Name
                })
                .ToList();

            var viewModel = new RoomServiceViewModel
            {
                Jobs = new SelectList(jobs, "Value", "Text")
            };

            return View(viewModel);
        }

        // POST: RoomServices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Job_ID,Room_Service_Name,Room_Service_Description,Room_Service_Active")] RoomService roomService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = roomService.ID_Room_Service, savedNow = true });
            }

            // Recarregar a lista de Jobs em caso de falha
            var jobs = _context.Job.Select(j => new SelectListItem
            {
                Value = j.Job_ID.ToString(),
                Text = j.Job_Name
            }).ToList();

            var viewModel = new RoomServiceViewModel
            {
                ID_Room_Service = roomService.ID_Room_Service,
                Room_Service_Name = roomService.Room_Service_Name,
                Jobs = new SelectList(jobs, "Value", "Text")
            };

            return View(viewModel);
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

            var jobs = _context.Job.Select(j => new SelectListItem
            {
                Value = j.Job_ID.ToString(),
                Text = j.Job_Name
            }).ToList();

            var viewModel = new RoomServiceViewModel
            {
                ID_Room_Service = roomService.ID_Room_Service,
                Room_Service_Name = roomService.Room_Service_Name,
                Jobs = new SelectList(jobs, "Value", "Text")
            };

            return View(viewModel);
        }

        // POST: RoomServices/Edit/5
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
                        return RedirectToAction(nameof(Create), new { Name = roomService.Room_Service_Name });
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Details), new { id = roomService.ID_Room_Service, savedNow = true });
            }

            // Recarregar a lista de Jobs em caso de falha
            var jobs = _context.Job.Select(j => new SelectListItem
            {
                Value = j.Job_ID.ToString(),
                Text = j.Job_Name
            }).ToList();

            var viewModel = new RoomServiceViewModel
            {
                ID_Room_Service = roomService.ID_Room_Service,
                Room_Service_Name = roomService.Room_Service_Name,
                Jobs = new SelectList(jobs, "Value", "Text")
            };

            return View(viewModel);
        }

        // Métodos de Delete mantidos sem alterações
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService
                .FirstOrDefaultAsync(m => m.ID_Room_Service == id);

            if (roomService == null)
            {
                ViewBag.Entity = "RoomService";
                ViewBag.Controller = "RoomServices";
                ViewBag.Action = "Index";
                return View("DeleteSuccess");
            }

            return View(roomService);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomService = await _context.RoomService.FindAsync(id);

            if (roomService != null)
            {
                _context.RoomService.Remove(roomService);
                await _context.SaveChangesAsync();
            }

            ViewBag.Entity = "RoomService";
            ViewBag.Controller = "RoomServices";
            ViewBag.Action = "Index";
            return View("DeleteSuccess");
        }

        private bool RoomServiceExists(int id)
        {
            return _context.RoomService.Any(e => e.ID_Room_Service == id);
        }
    }
}
