using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService : IBaseService<Project, ProjectEntity, ProjectRegForm>
{
    Task<Project> UpdateProjectAsync(Project project);
}
