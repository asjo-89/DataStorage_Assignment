using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerRegForm dto)
        {
            if (dto == null) return BadRequest("No data available to create customer.");

            Customer newCustomer = await _customerService.CreateAsync(dto);

            if (newCustomer == null) return BadRequest("Failed to create customer.");

            return Ok(newCustomer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Customer> customers = await _customerService.GetAllAsync();

            if (customers == null) return NotFound("No customers found.");

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            Customer customer = await _customerService.GetOneAsync(x => x.Id == id);
            if (customer == null) return NotFound("No customer found.");

            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Customer customer)
        {
            Customer updatedCustomer = await _customerService.UpdateAsync(customer);
            if (updatedCustomer != null) return Ok(customer);

            return NotFound("Update failed. Customer was not found.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Customer customer)
        {
            bool deleted = await _customerService.DeleteAsync(customer);
            if (deleted == false) return NotFound("No customer found. Failed to delete customer.");

            return Ok(deleted);
        }
    }
}
