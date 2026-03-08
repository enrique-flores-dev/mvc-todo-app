using Microsoft.AspNetCore.Mvc;
using mvctodolist.Models;
using System.Linq;

namespace mvctodolist.Controllers
{
    public class ToDoController : Controller
    {
        private static List<ToDoItem> _tasks = new();

        public IActionResult Index()
        {
            return View(_tasks);
        }

        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                var item = new ToDoItem
                {
                    Id = _tasks.Count + 1,
                    Title = title.Trim(),
                    IsComplete = false
                };
                _tasks.Add(item);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.IsComplete = true;
            }
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _tasks.Remove(task);
            }

            return RedirectToAction("Index");
        }
    }
}