using _10_CascadingDropdownListDAL;
using Microsoft.AspNetCore.Mvc;

namespace _10_CascadingDropdownListWebTask.Controllers
{
    public class LocationController : Controller
    {
        AppDbContext _db;
        public LocationController(AppDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Country()
        {
            var co = _db.Countries.ToList();
            return new JsonResult(co);
        }

        public JsonResult City(int id)
        {
            var ci = _db.Cities.Where(e => e.Country.CountryId == id)
                .ToList();

            return new JsonResult(ci);
        }
    }
}
