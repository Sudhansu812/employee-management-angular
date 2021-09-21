using AutoMapper;
using EmployeeDetails.Models;
using EmployeeDetails.Models.Dtos;
using EmployeeDetails.Repos.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepo _repository;
        private readonly IMapper _mapper;

        public DepartmentServices(IDepartmentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<DepartmentReadDto> Create(DepartmentCreateDto departmentCreateDto)
        {
            DepartmentModel department = _mapper.Map<DepartmentModel>(departmentCreateDto);
            try
            {
                _repository.Create(department);
            }
            catch
            {
                return null;
            }
            if (_repository.SaveChanges() == false)
            {
                return null;
            }
            return Task.Run(() => _mapper.Map<DepartmentReadDto>(department));
        }

        public Task<bool> Delete(int id)
        {
            DepartmentModel department = _repository.GetById(id);
            if (department == null)
            {
                return Task.Run(() => false);
            }
            try
            {
                _repository.Delete(department);
            }
            catch
            {
                return Task.Run(() => false);
            }
            return Task.Run(() => _repository.SaveChanges());
        }

        public Task<IEnumerable<DepartmentReadDto>> GetAll()
        {
            List<DepartmentModel> departments = (List<DepartmentModel>)_repository.GetAll();
            return Task.Run(() => _mapper.Map<IEnumerable<DepartmentReadDto>>(departments));
        }

        public Task<DepartmentReadDto> GetById(int id)
        {
            DepartmentModel department = _repository.GetById(id);
            if (department == null)
            {
                return null;
            }
            return Task.Run(() => _mapper.Map<DepartmentReadDto>(department));
        }

        public Task<DepartmentUpdateDto> Patch(int id, JsonPatchDocument<DepartmentUpdateDto> jsonPatchDocument, ModelStateDictionary ModelState)
        {
            DepartmentModel department = _repository.GetById(id);
            if (department == null)
            {
                return null;
            }
            DepartmentUpdateDto departmentUpdateDto = _mapper.Map<DepartmentUpdateDto>(department);
            jsonPatchDocument.ApplyTo(departmentUpdateDto, ModelState);
            return Task.Run(() => departmentUpdateDto);
        }

        public Task<bool> SavePatchedDetails(int id, DepartmentUpdateDto departmentPatchUpdateDto)
        {
            DepartmentModel department = _repository.GetById(id);
            _mapper.Map(departmentPatchUpdateDto, department);
            _repository.Update(department);
            return Task.Run(() => _repository.SaveChanges());
        }

        public Task<bool> Update(int id, DepartmentReadDto departmentReadDto)
        {
            DepartmentModel department = _repository.GetById(id);
            DepartmentUpdateDto departmentUpdateDto = new DepartmentUpdateDto();
            departmentUpdateDto.DepartmentName = departmentReadDto.DepartmentName;
            if (department == null)
            {
                return Task.Run(() => false);
            }
            _mapper.Map(departmentUpdateDto, department);
            _repository.Update(department);
            return Task.Run(() => _repository.SaveChanges());
        }
    }
}
