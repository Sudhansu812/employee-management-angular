using AutoMapper;
using EmployeeDetails.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models.Profiles
{
    public class DepartmentProfiles : Profile
    {
        public DepartmentProfiles()
        {
            CreateMap<DepartmentModel, DepartmentReadDto>();
            CreateMap<DepartmentModel, DepartmentUpdateDto>();
            CreateMap<DepartmentCreateDto, DepartmentModel>();
            CreateMap<DepartmentUpdateDto, DepartmentModel>();
        }
    }
}
