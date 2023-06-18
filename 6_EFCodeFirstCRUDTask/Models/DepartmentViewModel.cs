using System.ComponentModel.DataAnnotations;

namespace _6_EFCodeFirstCRUDTask.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Enter Name")] 
        public string Name { get; set; }
    }
}
