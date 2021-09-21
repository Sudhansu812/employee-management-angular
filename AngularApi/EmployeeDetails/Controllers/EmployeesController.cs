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
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeesController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        // GET api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAll()
        {
            return Ok((List<EmployeeReadDto>)await _employeeServices.GetAll());
        }

        // GET api/employees/5
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeReadDto>> GetById(int id)
        {
            EmployeeReadDto customer = (EmployeeReadDto)await _employeeServices.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/employees
        [HttpPost]
        public async Task<ActionResult<EmployeeReadDto>> Create(EmployeeCreateDto customerCreateDto)
        {
            EmployeeReadDto employee = await _employeeServices.Create(customerCreateDto);
            if (employee == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute(nameof(GetById), new { Id = employee.EmployeeId }, employee);
        }

        // PUT api/employees/5
        [HttpPut]
        public async Task<ActionResult> Update(EmployeeReadDto employeeReadDto)
        {
            bool updateResult = await _employeeServices.Update(employeeReadDto.EmployeeId, employeeReadDto);
            if (!updateResult)
            {
                return NotFound();
            }
            return NoContent();
        }

        // PATCH api/employees/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<EmployeeUpdateDto> jsonPatchDocument)
        {
            EmployeeUpdateDto customer = await _employeeServices.Patch(id, jsonPatchDocument, ModelState);
            if (!TryValidateModel(customer))
            {
                return ValidationProblem(ModelState);
            }
            if (await _employeeServices.SavePatchedDetails(id, customer) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleteResult = await _employeeServices.Delete(id);
            if (deleteResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
