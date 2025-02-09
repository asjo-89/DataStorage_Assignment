using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IServicesService servicesService) : ControllerBase
    {
        private readonly IServicesService _servicesService = servicesService;

        [HttpPost]
        public async Task<IActionResult> CreateServiceAsync(ServiceDto dto)
        {
            if (dto == null) return BadRequest("No data available to create service.");

            Service service = await _servicesService.CreateAsync(dto);
            if (service == null) return BadRequest("Failed to create service.");

            return Ok(ServiceFactory.CreateDtoFromModel(service));
        }

        //[HttpPost("unit")]
        //public async Task<IActionResult> CreateUnitAsync(UnitDto dto)
        //{
        //    if (dto == null) return BadRequest("No data available to create unit.");

        //    Unit unit = await _unitService.CreateAsync(dto);
        //    if (unit == null) return BadRequest("Failed to create unit.");

        //    return Ok(UnitFactory.CreateDtoFromModel(unit));
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var services = await _servicesService.GetAllAsync();
            if (services.Count == 0) return NotFound("There are no services in the list.");
            return Ok(await _servicesService.GetAllAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0) return BadRequest("Invalid id. No service was deleted.");

            var deleted = await _servicesService.DeleteAsync(id);
            if (!deleted) return NotFound("No service was found.");

            return Ok("The service was successfully deleted.");
        }
    }
}
