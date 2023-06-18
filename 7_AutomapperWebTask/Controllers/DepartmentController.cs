using _7_AutomapperDAL;
using _7_AutomapperDAL.Entities;
using _7_AutomapperWebTask.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _7_AutomapperWebTask.Controllers
{
    public class DepartmentController : Controller
    {
        AppDbContext _db;
        IMapper _mapper;

        public DepartmentController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var depts = _db.Departments.Select(p => p).ToList();
            var model = _mapper.Map<IEnumerable<DepartmentViewModel>>(depts);

            return View(model);
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
                Department department = _mapper.Map<Department>(model);
                _db.Departments.Add(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            DepartmentViewModel model = null;
            Department data = _db.Departments.Find(id);
            if (data != null)
            {
                model = _mapper.Map<DepartmentViewModel>(data);
            }
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = _mapper.Map<Department>(model);

                _db.Departments.Update(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Department model = _db.Departments.Find(id);
            if (model != null)
            {
                _db.Departments.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
