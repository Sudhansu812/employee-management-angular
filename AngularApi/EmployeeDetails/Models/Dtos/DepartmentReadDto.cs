using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models.Dtos
{
    public class DepartmentReadDto
    {
        [Key]
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}
