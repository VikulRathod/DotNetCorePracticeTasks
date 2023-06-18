﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _8_StoredProceduresWithEFWebTask.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please Enter Name")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Address")] 
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Select Department")]
        [Display(Name = "Department")] 
        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }
    }
}
