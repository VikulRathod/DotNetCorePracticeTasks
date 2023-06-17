using _4_PassingDataUsingViewBagTempDataSessionTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _4_PassingDataUsingViewBagTempDataSessionTask.Controllers
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
            if (ModelState.IsValid)
            {
                if (model.Username == "user@gmail.com"
                    && model.Password == "123456")
                {
                    TempData["Message"] = "Welcome Back!";

                    string strUser = JsonSerializer.Serialize(model);
                    HttpContext.Session.SetString("User", strUser);

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Username or Password doesn't exist!";
                }
            }
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}
