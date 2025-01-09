using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Models;
using System.Diagnostics;

namespace ReserveSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AccessDenied()
        {
            ViewBag.Title = "Acesso Negado";
            ViewBag.Entity = "P�gina Restrita"; // Pode ser substitu�do dinamicamente
            ViewBag.Action = "Index"; // A��o padr�o para voltar ao menu
            ViewBag.Controller = "Home"; // Controlador padr�o

            return View("~/Views/Shared/AccessDenied.cshtml");
        }
    }
}
