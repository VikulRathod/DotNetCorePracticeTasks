using Microsoft.AspNetCore.Mvc;

namespace _2_RoutingAndNavigationTask.Areas.User.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
