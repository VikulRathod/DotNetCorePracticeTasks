using X.PagedList;

namespace _11_SearchSortPagingTask.Models
{
    public class EmployeeModel
    {
        public IPagedList<EmployeeViewModel> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }
    }
}
