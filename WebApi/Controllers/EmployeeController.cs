using Business.Dtos;
using Business.Factories;
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
                       
            Employee newEmployee = await _employeeService.CreateAsync(dto);

            if(newEmployee == null) return BadRequest("Failed to create employee.");
            return Ok(EmployeeFactory.CreateDtoFromModel(newEmployee));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _employeeService.GetAllAsync();

            if (employees == null || employees.Count <= 0) return NotFound("No employees found.");

            return Ok(employees);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetEmployeesAsync([FromQuery] string field, [FromQuery] string value)
        {
            ICollection<Employee> employees = await _employeeService.GetEmployeesWithDetailsAsync(field, value);
            if (employees.Count == 0) return NotFound("No employee was found.");

            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest("Invalid id in request. Id can't be changed.");
            Employee updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employee);
            if (updatedEmployee != null) return Ok(updatedEmployee);

            return NotFound("Update failed. Employee was not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool deleted = await _employeeService.DeleteAsync(id);
            if (deleted == false) return NotFound("No employee found. Failed to delete employee.");

            return Ok("The employee was successfully deleted.");
        }
    }
}