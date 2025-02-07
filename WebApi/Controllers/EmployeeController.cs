using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;


        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeDto dto)
        {
            if (dto == null) return BadRequest("No data available to create employee.");

            var firstName = await _employeeService.AlreadyExistsAsync(_employeeService.CreateExpressionAsync("FirstName", dto.FirstName));
            if (firstName) return BadRequest("An employee with the same first name already exists.");

            var lastName = await _employeeService.AlreadyExistsAsync(_employeeService.CreateExpressionAsync("LastName", dto.LastName));
            if (lastName) return BadRequest("An employee with the same last name already exists.");

            Employee newEmployee = await _employeeService.CreateAsync(dto);

            if(newEmployee == null) return BadRequest("Failed to create employee.");
            return Ok(newEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _employeeService.GetAllAsync();

            if (employees == null || employees.Count <= 0) return NotFound("No customers found.");

            return Ok(employees);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetEmployeeAsync([FromQuery] string field, [FromQuery] string value)
        {
            Employee employee = await _employeeService.GetEmployeeWithDetailsAsync(field, value);
            if (employee == null) return NotFound("No employee was found.");

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Employee employee)
        {
            bool update = await _employeeService.UpdateAsync(id, employee);
            if (update) return Ok(employee);

            return NotFound("Update failed. Employee was not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool deleted = await _employeeService.DeleteAsync(id);
            if (deleted == false) return NotFound("No employee found. Failed to delete employee.");

            return Ok(deleted);
        }
    }
}