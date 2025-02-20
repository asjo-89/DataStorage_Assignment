using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;


        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeRegForm dto)
        {
            if (dto == null) return BadRequest("No data available to create employee.");
                       
            Employee newEmployee = await _employeeService.CreateAsync(dto);
            if(newEmployee == null) return BadRequest("Failed to create employee.");

            return Ok(newEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Employee> employees = await _employeeService.GetAllAsync();

            if (employees == null) return NotFound("No employees found.");

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            Employee employee = await _employeeService.GetOneAsync(x => x.Id == id);
            if (employee == null) return BadRequest("No employee was found");
            return Ok(employee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Employee employee)
        {
            if (employee == null) return BadRequest("Failed to update employee.");
            Employee updatedEmployee = await _employeeService.UpdateAsync(employee);
            if (updatedEmployee != null) return Ok(updatedEmployee);

            return NotFound("Update failed. Employee was not found.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Employee employee)
        {
            bool deleted = await _employeeService.DeleteAsync(employee);
            if (deleted == false) return NotFound("No employee found. Failed to delete employee.");

            return Ok("The employee was successfully deleted.");
        }
    }
}