using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
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
        public async Task<IActionResult> CreateAsync(ProjectDto dto)
        {
            Console.WriteLine($"Received DTO: {JsonConvert.SerializeObject(dto)}");

            if (dto == null) return BadRequest("No data available to create new project.");
            
            Project project = await _projectService.CreateAsync(dto);
            if (project == null) return BadRequest("Project could not be created.");

            ProjectDto newProject = ProjectFactory.CreateDtoFromModel(project);
            return Ok(newProject);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var projects = await _projectService.GetAllAsync();
            if (projects == null || projects.Count == 0) return NotFound("No projects was found.");
   
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectAsync(int id)
        {
            Project project = await _projectService.GetProjectAsync(id);
            if (project == null) return NotFound("No project found.");

            ProjectDto projectDto = ProjectFactory.CreateDtoFromModel(project);
            return Ok(projectDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProjectDto dto)
        {
            if (id != dto.Id) return BadRequest("Invalid request. Id can't be changed.");
            
            Project projectToUpdate = ProjectFactory.CreateModelFromDto(dto);
            if (projectToUpdate == null) return BadRequest("Could not convert dto to model.");

            Project? project = await _projectService.UpdateProjectAsync(id, projectToUpdate);
            if (project == null) return BadRequest("Unable to update project.");

            ProjectDto updatedProject = ProjectFactory.CreateDtoFromModel(project);

            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0) return BadRequest("Invalid request. Project could not be deleted.");

            bool deleted = await _projectService.DeleteAsync(id);
            return deleted ? Ok("Project was successfully deleted") : NotFound("Failed to delete project. Project was not found.");
        }
    }
}
