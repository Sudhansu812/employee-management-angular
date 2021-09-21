using EmployeeDetails.Models.Dtos;
using EmployeeDetails.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;
        public DepartmentsController(IDepartmentServices employeeServices)
        {
            _departmentServices = employeeServices;
        }

        // GET api/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentReadDto>>> GetAll()
        {
            return Ok((List<DepartmentReadDto>)await _departmentServices.GetAll());
        }

        // GET api/departments/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<DepartmentReadDto>> GetById(int id)
        {
            DepartmentReadDto department = (DepartmentReadDto)await _departmentServices.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        // POST api/departments
        [HttpPost]
        public async Task<ActionResult<DepartmentReadDto>> Create(DepartmentCreateDto departmentCreateDto)
        {
            DepartmentReadDto department = await _departmentServices.Create(departmentCreateDto);
            if (department == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute(nameof(GetById), new { Id = department.DepartmentId }, department);
        }

        // PUT api/departments/5
        [HttpPut]
        public async Task<ActionResult> Update(DepartmentReadDto departmentReadDto)
        {
            bool updateResult = await _departmentServices.Update(departmentReadDto.DepartmentId, departmentReadDto);
            if (!updateResult)
            {
                return NotFound();
            }
            return NoContent();
        }

        // PATCH api/departments/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<DepartmentUpdateDto> jsonPatchDocument)
        {
            DepartmentUpdateDto department = await _departmentServices.Patch(id, jsonPatchDocument, ModelState);
            if (!TryValidateModel(department))
            {
                return ValidationProblem(ModelState);
            }
            if (await _departmentServices.SavePatchedDetails(id, department) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE api/departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleteResult = await _departmentServices.Delete(id);
            if (deleteResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
