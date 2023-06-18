using _8_StoredProceduresWithEFDAL;
using _8_StoredProceduresWithEFDAL.Entities;
using _8_StoredProceduresWithEFWebTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace _8_StoredProceduresWithEFWebTask.Controllers
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
            IList<EmployeeViewModel> model = new List<EmployeeViewModel>();
            var data = _db.Procedures.UspGetEmployees();
            if (data != null)
            {
                foreach (var item in data)
                {
                    EmployeeViewModel employee = new EmployeeViewModel();
                    employee.EmployeeId = item.EmployeeId;
                    employee.Name = item.Name;
                    employee.Address = item.Address;
                    employee.DepartmentId = item.DepartmentId;
                    employee.DepartmentName = item.DepartmentName;
                    model.Add(employee);
                }
            }
            return View(model);
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
                _db.Procedures.UspAddEmployee(employee);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Employee data = _db.Procedures.UspGetEmployee(id);
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
