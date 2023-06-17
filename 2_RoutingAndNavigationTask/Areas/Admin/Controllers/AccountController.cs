using Microsoft.AspNetCore.Mvc;

namespace _2_RoutingAndNavigationTask.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
