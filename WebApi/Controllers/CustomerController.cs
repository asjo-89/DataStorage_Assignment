using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerDto dto)
        {
            if (dto == null) return BadRequest("No data available to create customer.");

            Customer newCustomer = await _customerService.CreateAsync(dto);

            if (newCustomer == null) return BadRequest("Failed to create customer.");

            return Ok(CustomerFactory.CreateDtoFromModel(newCustomer));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();

            if (customers == null || customers.Count <= 0) return NotFound("No customers found.");

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            Customer customer = await _customerService.GetOneAsync(x => x.Id == id);
            CustomerDto dto = CustomerFactory.CreateDtoFromModel(customer);
            if (dto == null) return NotFound("No customer found.");

            return Ok(dto);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCustomerAsync([FromQuery] string field, [FromQuery] string value)
        {
            Customer customer = await _customerService.GetCustomerWithDetailsAsync(field, value);
            if (customer == null) return NotFound("No customer was found.");

            return Ok(CustomerFactory.CreateDtoFromModel(customer));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]Customer customer)
        {
            bool update = await _customerService.UpdateAsync(id, customer);
            if (update) return Ok(customer);

            return NotFound("Update failed. Customer was not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool deleted = await _customerService.DeleteAsync(id);
            if (deleted == false) return NotFound("No customer found. Failed to delete customer.");

            return Ok(deleted);
        }
    }
}
