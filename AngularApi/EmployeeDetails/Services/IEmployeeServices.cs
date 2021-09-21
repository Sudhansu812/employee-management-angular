using EmployeeDetails.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<EmployeeReadDto>> GetAll();

        Task<EmployeeReadDto> GetById(int id);

        Task<EmployeeReadDto> Create(EmployeeCreateDto employeeCreateDto);

        Task<bool> Update(int id, EmployeeReadDto employeeReadDto);

        Task<EmployeeUpdateDto> Patch(int id, JsonPatchDocument<EmployeeUpdateDto> jsonPatchDocument, ModelStateDictionary ModelState);

        Task<bool> SavePatchedDetails(int id, EmployeeUpdateDto employeePatchUpdateDto);

        Task<bool> Delete(int id);
    }
}
