using System.ComponentModel.DataAnnotations;

namespace _6_EFCodeFirstCRUDDAL.Entities
{
    public class Department
    {
        [Key] 
        public int DepartmentId { get; set; }

        [Required] 
        public string Name { get; set; }
    }
}
