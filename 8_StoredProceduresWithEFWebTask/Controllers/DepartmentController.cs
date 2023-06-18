using _8_StoredProceduresWithEFDAL;
using _8_StoredProceduresWithEFDAL.Entities;
using _8_StoredProceduresWithEFWebTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace _8_StoredProceduresWithEFWebTask.Controllers
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
            var depts = _db.Departments
                .Select(p =>
                new DepartmentViewModel
                {
                    DepartmentId = p.DepartmentId,
                    Name = p.Name
                }
                ).ToList();

            return View(depts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel model)
        {
            ModelState.Remove("DepartmentId");
            if (ModelState.IsValid)
            {
                Department department = new Department { Name = model.Name };
                _db.Departments.Add(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            DepartmentViewModel model = new DepartmentViewModel();
            Department data = _db.Departments.Find(id);
            if (data != null)
            {
                model = new DepartmentViewModel
                {
                    DepartmentId = data.DepartmentId,
                    Name = data.Name
                };
            }
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department
                {
                    DepartmentId = model.DepartmentId,
                    Name = model.Name
                };
                _db.Departments.Update(department);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Department model =
                _db.Departments.Find(id);

            if (model != null)
            {
                _db.Departments.Remove(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
