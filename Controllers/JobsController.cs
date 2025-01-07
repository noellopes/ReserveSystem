using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class JobsController : Controller
    {
        private readonly ReserveSystemContext _context;

        public JobsController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index(int page = 1, string searchJobName = "", string searchJobDescription = "")
        {
            int pageSize = 5; // Número de itens por página

            var jobsQuery = _context.Job.AsQueryable();

            // Filtragem
            if (!string.IsNullOrEmpty(searchJobName))
            {
                jobsQuery = jobsQuery.Where(j => j.JobName.Contains(searchJobName));
            }
            if (!string.IsNullOrEmpty(searchJobDescription))
            {
                jobsQuery = jobsQuery.Where(j => j.JobDescription.Contains(searchJobDescription));
            }

            // Total de itens
            var totalItems = await jobsQuery.CountAsync();

            // Inicializar o PagingInfo
            var pagingInfo = new PagingInfo
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = page
            };

            // Paginação
            var jobs = await jobsQuery
                .OrderBy(j => j.JobName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Inicializar o ViewModel
            var viewModel = new JobsViewModel
            {
                Jobs = jobs,
                SearchJobName = searchJobName,
                SearchJobDescription = searchJobDescription,
                PagingInfo = pagingInfo
            };

            return View(viewModel);
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .FirstOrDefaultAsync(m => m.JobId == id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,JobName,JobDescription")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();

                // Redirecionar para a página de confirmação de registo, passando o Id do jov
                return RedirectToAction("RegistrationComplete", "Jobs", new { jobId = job.JobId });
            }
            return View(job);
        }

        public async Task<IActionResult> RegistrationComplete(int jobId)
        {
            var job = await _context.Job.FirstOrDefaultAsync(j => j.JobId == jobId);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }


        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,JobName,JobDescription")] Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();

                    // Redireciona para a página de sucesso com a mensagem e os dados atualizados
                    return RedirectToAction("EditSuccess", new { jobId = job.JobId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(job);
        }

        // GET: Jobs/EditSuccess
        public async Task<IActionResult> EditSuccess(int jobId)
        {
            var job = await _context.Job
                .FirstOrDefaultAsync(j => j.JobId == jobId);

            if (job == null)
            {
                return NotFound();
            }

            // Mensagem de sucesso
            ViewBag.Message = "Job edited successfully!";
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Job.FindAsync(id);
            if (job != null)
            {
                _context.Job.Remove(job);
                await _context.SaveChangesAsync();
            }

            // Redireciona para a página de confirmação de exclusão
            return RedirectToAction("DeleteSuccess", new { itemName = job?.JobName });
        }

        // GET: Jobs/DeleteSuccess
        public IActionResult DeleteSuccess(string itemName)
        {
            ViewBag.ItemName = itemName;
            return View();
        }

        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.JobId == id);
        }
    }
}
