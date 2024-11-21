using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Invalid Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public required string Type { get; set; }
    }
}
