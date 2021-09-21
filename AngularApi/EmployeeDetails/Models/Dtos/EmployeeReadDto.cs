using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models.Dtos
{
    public class EmployeeReadDto
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeDepartment { get; set; }

        [Required]
        public string EmployeeEmail { get; set; }

        public DateTime? EmployeeDoj { get; set; }
    }
}
