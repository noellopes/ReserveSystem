using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Diagnostics;

namespace ReserveSystem.Controllers
{
    public class HomeController : Controller {
        private readonly ReserveSystemContext _context;
        private readonly ILogger<HomeController> _logger; // Added for logging


        public HomeController(ReserveSystemContext context, ILogger<HomeController> logger) {
            _context = context;
            _logger = logger; // Agora, o logger é inicializado corretamente
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ClienteHome()
        {
            return View();
        }

        public IActionResult FuncionarioHome()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
