using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context) 
        {
              this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var wishs = context.ToDoList.ToList(); 
            return View(wishs);
            
        }
        [HttpPost]
        public async Task<IActionResult> Index(ToDo toDo)
        {
            context.Add(toDo);
            await context.SaveChangesAsync();
            return RedirectToAction("Home","Index");
        }

        [HttpPost]
        public async Task<IActionResult> Deleted(int Id)
        {
            var wish = await context.ToDoList.FindAsync(Id);
            context.ToDoList.Remove(wish);
            await context.SaveChangesAsync();
            return RedirectToAction("Home","Deleted");
        }

        [HttpGet]
        public async Task<IActionResult>Edit(int Id)
        {
            var NewWish = await context.ToDoList.FindAsync(Id);
            return View(NewWish);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(ToDo toDo)
        {
            context.Update(toDo);
            await context.SaveChangesAsync();
            return RedirectToAction("Home","Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
