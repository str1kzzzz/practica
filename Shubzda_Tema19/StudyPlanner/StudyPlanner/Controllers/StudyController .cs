using Microsoft.AspNetCore.Mvc;
using StudyPlanner.Models;
using System.Linq;

namespace StudyPlanner.Controllers
{
    public class StudyController : Controller
    {
        private static List<StudyTask> tasks = new List<StudyTask>();

        public IActionResult Upcoming()
        {
            var upcoming = tasks
                .Where(t => !t.Completed)
                .OrderBy(t => t.Deadline)
                .ToList();

            return View(upcoming);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(StudyTask task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            return RedirectToAction("Upcoming");
        }

        public IActionResult Complete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            task.Completed = true;
            return RedirectToAction("Upcoming");
        }
    }
}
