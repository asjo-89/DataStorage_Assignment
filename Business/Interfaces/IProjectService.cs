using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService : IBaseService<Project, ProjectEntity, ProjectRegForm>
{
    Task<Project> GetProjectAsync(int id);
    Task<Project?> UpdateProjectAsync(int id, Project project);
}
