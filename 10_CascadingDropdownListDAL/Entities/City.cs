﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace _10_CascadingDropdownListDAL.Entities
{
    public partial class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}