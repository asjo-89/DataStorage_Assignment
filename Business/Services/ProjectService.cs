using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IBaseRepository<ProjectEntity> repository) : BaseService<Project, ProjectEntity>(repository, ProjectFactory.CreateModelFromEntity, ProjectFactory.CreateEntityFromModel), IProjectService
{
    //public async Task<Project> CreateAsync(ProjectDto dto)
    //{
    //    if (dto == null) return null!;

    //    Project project = ProjectFactory.CreateModelFromDto(dto);

    //    return await _repository.CreateAsync(project);
    //}
    public Task<Project> CreateAsync(ProjectDto dto)
    {
        throw new NotImplementedException();
    }
}
