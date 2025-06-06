﻿using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServicesController(IServicesService servicesService) : ControllerBase
    {
        private readonly IServicesService _servicesService = servicesService;

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateServiceAsync(ServiceRegForm dto)
        {
            if (dto == null) return BadRequest("No data available to create service.");

            Service service = await _servicesService.CreateAsync(dto);
            if (service == null) return BadRequest("Failed to create service.");

            return Ok(service);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Service> services = await _servicesService.GetAllAsync();
            if (services == null) return NotFound("There are no services in the list.");
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            Service service = await _servicesService.GetOneAsync(x => x.Id == id);
            if (service == null) return BadRequest("No status was found");
            return Ok(service);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Service model)
        {
            if (model == null) return BadRequest("Incorrect data. Failed to update role.");

            Service? service = await _servicesService.UpdateAsync(model);
            if (service == null) return BadRequest("Unable to update project.");

            return Ok(service);
        }

        //Att fixa: Ska inte gå att ta bort om en tjänst är kopplad till ett projekt.

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Service service)
        {
            if (service == null) return BadRequest("Invalid id. No service was deleted.");

            bool deleted = await _servicesService.DeleteAsync(service);
            if (!deleted) return NotFound("No service was found.");

            return Ok("The service was successfully deleted.");
        }
    }
}
