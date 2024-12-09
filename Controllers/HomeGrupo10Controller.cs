using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReserveSystem.Controllers
{
	public class HomeGrupo10Controller : Controller
	{
		// GET: HomeGrupo10Controller
		public ActionResult Index()
		{
			return View();
		}

		// GET: HomeGrupo10Controller/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: HomeGrupo10Controller/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: HomeGrupo10Controller/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HomeGrupo10Controller/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: HomeGrupo10Controller/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HomeGrupo10Controller/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: HomeGrupo10Controller/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
