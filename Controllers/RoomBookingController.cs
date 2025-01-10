using Microsoft.AspNetCore.Mvc;

namespace ReserveSystem.Controllers
{
    public class RoomBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
