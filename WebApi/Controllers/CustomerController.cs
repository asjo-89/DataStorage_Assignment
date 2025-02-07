﻿using Business.Dtos;
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

            var customerName = await _customerService.AlreadyExistsAsync(_customerService.CreateExpressionAsync("CustomerName", dto.CustomerName));
            if (customerName) return BadRequest("A customer with the same name already exists");

            var phoneNumber = await _customerService.AlreadyExistsAsync(_customerService.CreateExpressionAsync("PhoneNumber", dto.PhoneNumber));
            if (phoneNumber) return BadRequest("The phone number is already assigned to another customer.");
            
            var email = await _customerService.AlreadyExistsAsync(_customerService.CreateExpressionAsync("Email", dto.Email));
            if (email) return BadRequest("The email is already assigned to another customer.");

            Customer newCustomer = await _customerService.CreateAsync(dto);

            if (newCustomer == null) return BadRequest("Failed to create customer.");

            return Ok(newCustomer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();

            if (customers == null || customers.Count <= 0) return NotFound("No customers found.");

            return Ok(customers);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCustomerAsync([FromQuery] string field, [FromQuery] string value)
        {
            Customer customer = await _customerService.GetCustomerWithDetailsAsync(field, value);
            if (customer == null) return NotFound("No customer was found.");

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Customer customer)
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
