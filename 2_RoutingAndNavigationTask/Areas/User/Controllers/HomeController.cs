using Microsoft.AspNetCore.Mvc;

namespace _2_RoutingAndNavigationTask.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
