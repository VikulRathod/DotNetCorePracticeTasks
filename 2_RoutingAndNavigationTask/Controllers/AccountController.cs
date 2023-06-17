using _2_RoutingAndNavigationTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2_RoutingAndNavigationTask.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model.Username == "user@gmail.com"
                && model.Password == "12345678")
            {
                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            else if (model.Username == "admin@gmail.com"
                && model.Password == "12345678")
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}
