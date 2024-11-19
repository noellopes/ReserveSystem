using Microsoft.AspNetCore.Mvc;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class TypeOfScheduleController : Controller
    {
        // We will use a temporary list instead of connecting to the database
        private static List<TypeOfSchedule> _typeOfSchedules = new List<TypeOfSchedule>
        {
            new TypeOfSchedule { TypeOfScheduleId = 1, TypeOfScheduleName = "Normal Shift" },
            new TypeOfSchedule { TypeOfScheduleId = 2, TypeOfScheduleName = "Prevention Shift" }
        };

        // Listing Process
        public IActionResult Index()
        {
            return View(_typeOfSchedules);
        }

        // GET method to create a new TypeOfSchedule
        public IActionResult Create()
        {
            return View();
        }

        // POST method for creating a new TypeOfSchedule
        [HttpPost]
        public IActionResult Create(TypeOfSchedule typeOfSchedule)
        {
            if (ModelState.IsValid)
            {
                typeOfSchedule.TypeOfScheduleId = _typeOfSchedules.Count + 1;
                _typeOfSchedules.Add(typeOfSchedule);
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfSchedule);
        }

        // GET method for update
        public IActionResult Edit(int id)
        {
            var schedule = _typeOfSchedules.FirstOrDefault(t => t.TypeOfScheduleId == id);
            if (schedule == null) return NotFound();
            return View(schedule);
        }

        // POST method for update
        [HttpPost]
        public IActionResult Edit(TypeOfSchedule typeOfSchedule)
        {
            var schedule = _typeOfSchedules.FirstOrDefault(t => t.TypeOfScheduleId == typeOfSchedule.TypeOfScheduleId);
            if (schedule != null)
            {
                schedule.TypeOfScheduleName = typeOfSchedule.TypeOfScheduleName;
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfSchedule);
        }

        // Delete operation
        public IActionResult Delete(int id)
        {
            var schedule = _typeOfSchedules.FirstOrDefault(t => t.TypeOfScheduleId == id);
            if (schedule != null)
            {
                _typeOfSchedules.Remove(schedule);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}