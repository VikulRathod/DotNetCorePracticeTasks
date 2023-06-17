using Microsoft.AspNetCore.Mvc;
using ViewComponentPartialViewTask.Models;

namespace ViewComponentPartialViewTask.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            PostViewModel model = new PostViewModel
            { 
                Id = 1, 
                Title = "What is ASP.NET Core", 
                Author = "Mahesh Parekh", 
                Body = "ASP.NET Core is an open-source framework for building UI and API..." 
            }; 

            return View(model);
        }
    }
}
