using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System.Linq;

namespace ReserveSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public LoginController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // Mostrar el formulario de inicio de sesión
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Procesar el inicio de sesión
        [HttpPost]
        public IActionResult Login(int Staff_id, string Password)
        {
            // Buscar el usuario en la base de datos
            var user = _context.UserLogin.FirstOrDefault(u => u.Staff_id == Staff_id && u.Password == Password);

            if (user != null)
            {
                // Usuario autenticado
                ViewBag.Message = "Succesful login!";
            }
            else
            {
                // Credenciales incorrectas
                ViewBag.Error = "User or password is incorrect.";
            }

            return View(); // Regresa a la misma vista, con mensajes
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserLogin user
            )
        {
            if (ModelState.IsValid)
            {
                _context.UserLogin.Add(user);
                _context.SaveChanges();
                ViewBag.Message = "User created successfully.";
            }
            else
            {
                ViewBag.Error = "Error creating user.";
            }

            return View();
        }
    }
}
