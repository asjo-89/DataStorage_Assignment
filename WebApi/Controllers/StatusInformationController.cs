using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusInformationController(IStatusInformationService statusInformationService) : ControllerBase
    {
        private readonly IStatusInformationService _statusInformationService = statusInformationService;

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StatusInformationRegForm dto)
        {
            if (dto == null) return BadRequest("No data available to create new status.");

            StatusInformation status = await _statusInformationService.CreateAsync(dto);
            if (status == null) return BadRequest("Failed to create status.");

            return Ok(StatusInformationFactory.CreateDtoFromModel(status));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var statuses =  await _statusInformationService.GetAllAsync();
            if (statuses == null) return BadRequest("No statuses was found");
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            StatusInformation status = await _statusInformationService.GetOneAsync(x => x.Id == id);
            StatusInformationRegForm dto = StatusInformationFactory.CreateDtoFromModel(status);
            if (dto == null) return BadRequest("No statuse was found");
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0) return BadRequest("Invalid id. No status was deleted.");
            bool deleted = await _statusInformationService.DeleteAsync(id);
            if (!deleted) return NotFound("No status was found.");
            return Ok("The status was successfully deleted.");
        }
    }
}
