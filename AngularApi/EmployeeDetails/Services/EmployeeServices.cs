using AutoMapper;
using EmployeeDetails.Interfaces.Repos;
using EmployeeDetails.Models;
using EmployeeDetails.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo _repository;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<EmployeeReadDto> Create(EmployeeCreateDto employeeCreateDto)
        {
            EmployeeModel employee = _mapper.Map<EmployeeModel>(employeeCreateDto);
            try
            {
                _repository.Create(employee);
            }
            catch
            {
                return null;
            }
            if (_repository.SaveChanges() == false)
            {
                return null;
            }
            return Task.Run(() => _mapper.Map<EmployeeReadDto>(employee));
        }

        public Task<bool> Delete(int id)
        {
            EmployeeModel employee = _repository.GetById(id);
            if (employee == null)
            {
                return Task.Run(() => false);
            }
            try
            {
                _repository.Delete(employee);
            }
            catch
            {
                return Task.Run(() => false);
            }
            return Task.Run(() => _repository.SaveChanges());
        }

        public Task<IEnumerable<EmployeeReadDto>> GetAll()
        {
            List<EmployeeModel> employees = (List<EmployeeModel>)_repository.GetAll();
            return Task.Run(() => _mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
        }

        public Task<EmployeeReadDto> GetById(int id)
        {
            EmployeeModel employee = _repository.GetById(id);
            if (employee == null)
            {
                return null;
            }
            return Task.Run(() => _mapper.Map<EmployeeReadDto>(employee));
        }

        public Task<EmployeeUpdateDto> Patch(int id, JsonPatchDocument<EmployeeUpdateDto> jsonPatchDocument, ModelStateDictionary ModelState)
        {
            EmployeeModel employee = _repository.GetById(id);
            if (employee == null)
            {
                return null;
            }
            EmployeeUpdateDto customerUpdateDto = _mapper.Map<EmployeeUpdateDto>(employee);
            jsonPatchDocument.ApplyTo(customerUpdateDto, ModelState);
            return Task.Run(() => customerUpdateDto);
        }

        public Task<bool> SavePatchedDetails(int id, EmployeeUpdateDto employeePatchUpdateDto)
        {
            EmployeeModel employee = _repository.GetById(id);
            _mapper.Map(employeePatchUpdateDto, employee);
            _repository.Update(employee);
            return Task.Run(() => _repository.SaveChanges());
        }

        public Task<bool> Update(int id, EmployeeReadDto employeeReadDto)
        {
            EmployeeModel employee = _repository.GetById(id);
            EmployeeUpdateDto employeeUpdateDto = new EmployeeUpdateDto();
            employeeUpdateDto.EmployeeName = employeeReadDto.EmployeeName;
            employeeUpdateDto.EmployeeEmail = employeeReadDto.EmployeeEmail;
            employeeUpdateDto.EmployeeDepartment = employeeReadDto.EmployeeDepartment;
            employeeUpdateDto.EmployeeDoj = employeeReadDto.EmployeeDoj;
            if (employee == null)
            {
                return Task.Run(() => false);
            }
            _mapper.Map(employeeUpdateDto, employee);
            _repository.Update(employee);
            return Task.Run(() => _repository.SaveChanges());
        }
    }
}
