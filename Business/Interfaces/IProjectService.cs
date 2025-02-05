using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService : IBaseService<Project, ProjectEntity>
{
    Task<Project> CreateAsync(ProjectDto dto);
}
