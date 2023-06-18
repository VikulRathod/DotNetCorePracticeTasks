﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_StoredProceduresWithEFDAL.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }


        [Required]
        public string Name { get; set; }
    }
}
