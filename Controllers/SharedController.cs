using Microsoft.AspNetCore.Mvc;

namespace ReserveSystem.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult RegistrationComplete(string entityName, string entityController)
        {
            // Passa os dados da entidade para a View
            ViewData["EntityName"] = entityName;
            ViewData["EntityController"] = entityController;
            return View();
        }
    }
}
