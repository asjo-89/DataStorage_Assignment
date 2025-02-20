using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProjectRegForm dto)
        {

            if (dto == null) return BadRequest("No data available to create new project.");
            
            Project project = await _projectService.CreateAsync(dto);
            if (project == null) return BadRequest("Project could not be created.");

            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Project> projects = await _projectService.GetAllAsync();
            if (!projects.Any()) return NotFound("No projects was found.");
   
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectAsync(int id)
        {
            Project project = await _projectService.GetOneAsync(x => x.Id == id);
            if (project == null) return NotFound("No project found.");

            return Ok(project);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ProjectRegForm dto)
        {
            if (dto == null) return BadRequest("Incorrect data. Failed to update project.");
            
            ProjectEntity entity = ProjectFactory.Create(dto);
            if (entity == null) return BadRequest("Failed to update project. Could not convert from form to model.");

            Project? project = await _projectService.UpdateAsync(ProjectFactory.Create(entity));
            if (project == null) return BadRequest("Unable to update project.");

            return Ok(project);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Project project)
        {
            if (project == null) return BadRequest("Invalid request. Project could not be deleted.");

            bool deleted = await _projectService.DeleteAsync(project);
            return deleted 
                ? Ok("Project was successfully deleted") 
                : NotFound("Failed to delete project. Project was not found.");
        }
    }
}
