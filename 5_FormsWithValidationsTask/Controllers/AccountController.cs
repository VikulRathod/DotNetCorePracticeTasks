using _5_FormsWithValidationsTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace _5_FormsWithValidationsTask.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
