using System.ComponentModel.DataAnnotations;

namespace _7_AutomapperWebTask.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
    }
}
