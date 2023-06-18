using _6_EFCodeFirstCRUDDAL;
using _6_EFCodeFirstCRUDDAL.Entities;
using _6_EFCodeFirstCRUDTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace _6_EFCodeFirstCRUDTask.Controllers
{
    public class EmployeeController : Controller
    {
        AppDbContext _db;

        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var data =
                (from e in _db.Employees
                 join d in _db.Departments
                 on e.DepartmentId equals d.DepartmentId
                 select new EmployeeViewModel
                 {
                     EmployeeId = e.EmployeeId,
                     Name = e.Name,
                     Address = e.Address,
                     DepartmentId = d.DepartmentId,
                     DepartmentName = d.Name
                 });

            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            ModelState.Remove("EmployeeId");

            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    Name = model.Name,
                    Address = model.Address,
                    DepartmentId = model.DepartmentId
                };

                _db.Add(employee);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Employee data = _db.Employees.Find(id);
            EmployeeViewModel model = new EmployeeViewModel();
            if (data != null)
            {
                model.EmployeeId = data.EmployeeId;
                model.Name = data.Name;
                model.Address = data.Address;
                model.EmployeeId = data.EmployeeId;
                model.DepartmentId = data.DepartmentId;
            }
            ViewBag.Departments = _db.Departments;
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    EmployeeId = model.EmployeeId,
                    Name = model.Name,
                    Address = model.Address,
                    DepartmentId = model.DepartmentId
                };
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _db.Departments.ToList();
            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            Employee model = _db.Employees.Find(id);
            if (model != null)
            {
                _db.Employees.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
