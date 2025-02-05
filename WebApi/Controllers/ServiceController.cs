using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

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

        //[HttpGet]
        //public async Task<IActionResult> GetByPropertyAsync(string name, Expression<Func<Customer, string>> expression)
        //{

        //}
    }
}
