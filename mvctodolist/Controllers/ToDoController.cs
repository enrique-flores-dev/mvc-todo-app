using Microsoft.AspNetCore.Mvc;
using mvctodolist.Data;
using mvctodolist.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace mvctodolist.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        }

        public IActionResult Index()
        {
            var tasks = _context.ToDoItems.Where(t => t.UserId == GetUserId()).ToList();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                var item = new ToDoItem
                {
                    Title = title.Trim(),
                    IsComplete = false,
                    UserId = GetUserId()
                };
                _context.ToDoItems.Add(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = _context.ToDoItems.FirstOrDefault(t => t.Id == id && t.UserId == GetUserId());
            if (task != null)
            {
                task.IsComplete = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.ToDoItems.FirstOrDefault(t => t.Id == id && t.UserId == GetUserId());
            if (task != null)
            {
                _context.ToDoItems.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}