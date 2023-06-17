using Microsoft.AspNetCore.Mvc;

namespace _4_PassingDataUsingViewBagTempDataSessionTask.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
