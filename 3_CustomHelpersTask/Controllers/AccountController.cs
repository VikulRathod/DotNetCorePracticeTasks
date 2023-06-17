using Microsoft.AspNetCore.Mvc;

namespace _3_CustomHelpersTask.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
