using _11_SearchSortPagingDAL;
using _11_SearchSortPagingTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace _11_SearchSortPagingTask.Controllers
{
    public class DepartmentController : Controller
    {
        AppDbContext _db;
        public DepartmentController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var departments = _db.Departments.ToList()
                .Select(d => new DepartmentViewModel()
                {
                    Name = d.Name
                });
            return View(departments);
        }
    }
}
