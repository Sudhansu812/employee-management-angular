using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models.Dtos
{
    public class DepartmentCreateDto
    {
        [Required]
        public string DepartmentName { get; set; }
    }
}
