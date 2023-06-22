using _11_SearchSortPagingDAL;
using _11_SearchSortPagingTask.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace _11_SearchSortPagingTask.Controllers
{
    public class EmployeeController : Controller
    {
        AppDbContext _db;
        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string search, string sortColumn, string sortOrder,
            int page = 1, int pageSize = 3)
        {
            List<EmployeeViewModel> employees = SearchedEmployees(search);

            List<EmployeeViewModel> sortedEmployees =
                SortedEmployees(employees, sortColumn, sortOrder);

            var employeesPerPage = sortedEmployees.ToPagedList(page, pageSize);

            EmployeeModel employee = new EmployeeModel()
            {
                Employees = employeesPerPage,
                CurrentPage = page,
                TotalPages = employeesPerPage.PageCount
            };

            return View(employee);
        }

        private List<EmployeeViewModel> SearchedEmployees(string search)
        {
            ViewBag.Search = search;

            List<EmployeeViewModel> employees = null;

            if (!string.IsNullOrEmpty(search))
            {
                employees = _db.Employees.Where(e =>
                e.Name.Contains(search) || e.Address.Contains(search))
                .Select(e =>
                new EmployeeViewModel()
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    Address = e.Address,
                    DepartmentId = e.DepartmentId
                }).ToList();
            }
            else
            {
                employees = _db.Employees
                .Select(e =>
                new EmployeeViewModel()
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    Address = e.Address,
                    DepartmentId = e.DepartmentId
                }).ToList();
            }

            return employees;
        }

        private List<EmployeeViewModel> SortedEmployees(List<EmployeeViewModel> employees,
            string sortColumn, string sortOrder)
        {
            List<EmployeeViewModel> sortedEmployees = employees;

            if (!string.IsNullOrEmpty(sortColumn))
            {
                ViewBag.SortColumn = sortColumn;
                ViewBag.SortOrderName = sortOrder;
                ViewBag.SortOrderAddress = sortOrder;
                ViewBag.SortOrderDepartmentId = sortOrder;
                ViewBag.SortOrderDepartmentName = sortOrder;

                switch (sortColumn)
                {
                    case "Address":
                        if (ViewBag.SortOrderAddress == "asc")
                        {
                            sortedEmployees
                                .Sort((x, y) => x.Address.CompareTo(y.Address));
                            ViewBag.SortOrderAddress = "desc";
                        }
                        else
                        {
                            sortedEmployees
                                .Sort((x, y) => y.Address.CompareTo(x.Address));
                            ViewBag.SortOrderAddress = "asc";
                        }
                        break;
                    case "DepartmentId":
                        if (ViewBag.SortOrderDepartmentId == "asc")
                        {
                            sortedEmployees
                                .Sort((x, y) => x.DepartmentId.CompareTo(y.DepartmentId));
                            ViewBag.SortOrderDepartmentId = "desc";
                        }
                        else
                        {
                            sortedEmployees
                                .Sort((x, y) => y.DepartmentId.CompareTo(x.DepartmentId));
                            ViewBag.SortOrderDepartmentId = "asc";
                        }
                        break;
                    case "DepartmentName":
                        if (ViewBag.SortOrderDepartmentName == "asc")
                        {
                            sortedEmployees
                                .Sort((x, y) => (x.DepartmentName != null) ?
                                x.DepartmentName.CompareTo(y.DepartmentName)
                                : 1);
                            ViewBag.SortOrderDepartmentName = "desc";
                        }
                        else
                        {
                            sortedEmployees
                                .Sort((x, y) => (y.DepartmentName != null) ?
                                y.DepartmentName.CompareTo(x.DepartmentName) : 1);
                            ViewBag.SortOrderDepartmentName = "asc";
                        }
                        break;
                    default:
                        if (ViewBag.SortOrderName == "asc")
                        {
                            sortedEmployees
                                .Sort((x, y) => x.Name.CompareTo(y.Name));
                            ViewBag.SortOrderName = "desc";
                        }
                        else
                        {
                            sortedEmployees
                                .Sort((x, y) => y.Name.CompareTo(x.Name));
                            ViewBag.SortOrderName = "asc";
                        }
                        break;
                }
            }

            return sortedEmployees;
        }
    }
}
