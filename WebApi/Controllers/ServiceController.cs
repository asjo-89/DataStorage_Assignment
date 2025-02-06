using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerDto dto)
        {
            if (dto == null) return BadRequest("No data available to create customer.");

            var customerName = await _customerService.AlreadyExistsAsync(_customerService.CreateExpressionAsync("CustomerName", dto.CustomerName));
            if (customerName) return BadRequest("A customer with the same name already exists");

            var phoneNumber = await _customerService.AlreadyExistsAsync(_customerService.CreateExpressionAsync("PhoneNumber", dto.PhoneNumber));
            if (phoneNumber) return BadRequest("The phone number is already assigned to another customer.");
            
            var email = await _customerService.AlreadyExistsAsync(_customerService.CreateExpressionAsync("Email", dto.Email));
            if (email) return BadRequest("The email is already assigned to another customer.");

            Customer newCustomer = await _customerService.CreateAsync(dto);

            return Ok(newCustomer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();

            if (customers == null || customers.Count <= 0) return NotFound("No customers found.");

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Customer customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound("No customer was found.");

            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, Customer customer)
        {
            bool update = await _customerService.UpdateAsync(id, customer);
            if (update) return Ok(customer);

            return NotFound("Update failed. Customer was not found.");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] string field, [FromQuery] string value)
        {
            var expression = _customerService.CreateExpressionAsync(field, value);
            if (expression == null) return BadRequest("Incorrect input.");

            bool deleted = await _customerService.DeleteAsync(expression);
            if (deleted == false) return NotFound("No customer found. Failed to delete customer.");

            return Ok(deleted);
        }
    }
}
