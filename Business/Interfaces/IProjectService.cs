using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService : IBaseService<Project, ProjectEntity, ProjectDto>
{
    Task<Project> GetProjectAsync(int id);
    Task<Project?> UpdateProjectAsync(int id, Project project);
}
