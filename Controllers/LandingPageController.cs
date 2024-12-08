using Microsoft.AspNetCore.Mvc;

namespace ReserveSystem.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
