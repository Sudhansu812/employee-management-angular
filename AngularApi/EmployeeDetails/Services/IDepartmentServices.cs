using EmployeeDetails.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Services
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<DepartmentReadDto>> GetAll();

        Task<DepartmentReadDto> GetById(int id);

        Task<DepartmentReadDto> Create(DepartmentCreateDto departmentCreateDto);

        Task<bool> Update(int id, DepartmentReadDto departmentReadDto);

        Task<DepartmentUpdateDto> Patch(int id, JsonPatchDocument<DepartmentUpdateDto> jsonPatchDocument, ModelStateDictionary ModelState);

        Task<bool> SavePatchedDetails(int id, DepartmentUpdateDto departmentPatchUpdateDto);

        Task<bool> Delete(int id);
    }
}
