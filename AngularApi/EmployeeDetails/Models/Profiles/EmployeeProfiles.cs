using AutoMapper;
using EmployeeDetails.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models.Profiles
{
    public class EmployeeProfiles : Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<EmployeeModel, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, EmployeeModel>();
            CreateMap<EmployeeUpdateDto, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeUpdateDto>();
        }
    }
}
