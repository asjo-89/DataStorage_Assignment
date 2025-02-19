using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService 
    : BaseService<Project, ProjectEntity, ProjectDto>, IProjectService
{
    protected readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
        : base(projectRepository,
            ProjectFactory.CreateModelFromEntity,
            ProjectFactory.CreateEntityFromModel,
            ProjectFactory.CreateEntityFromDto)
    {
        _projectRepository = projectRepository;
    }

    public override async Task<Project> CreateAsync(ProjectDto dto)
    {
        if (dto == null) return null!;
        if (await _repository.ExistsAsync(p => p.ProjectTitle == dto.ProjectTitle))
        {
            Debug.WriteLine("A project with the same title already exists.");
            return null!;
        }

        //Project newProject = await base.CreateAsync(dto);
        //return newProject ?? null!;

        ProjectEntity entity = await _repository.CreateAsync(ProjectFactory.CreateEntityFromDto(dto));
        if (entity == null!) return null!;

        entity = await _projectRepository.GetProjectAsync(entity.Id);

        Project newProject = ProjectFactory.CreateModelFromEntity(entity);
        return newProject ?? null!;
    }

    public override async Task<ICollection<Project>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllProjectsAsync();
        return projects.Select(p => ProjectFactory.CreateModelFromEntity(p)).ToList();
    }

    public async Task<Project> GetProjectAsync(int id)
    {
        if (id == 0) return null!;

        ProjectEntity entity = await _projectRepository.GetProjectAsync(id);
        if (entity == null) return null!;

        Project project = ProjectFactory.CreateModelFromEntity(entity);
        return project ?? null!;
    }

    public async Task<Project?> UpdateProjectAsync(int id, Project project)
    {
        if (project == null) return null!;
        
        ProjectEntity entity = ProjectFactory.CreateEntityFromModel(project);
        ProjectEntity? updatedEntity = await _repository.UpdateAsync(id, entity);
        updatedEntity = await _projectRepository.GetProjectAsync(id);
        if (updatedEntity == null) return null!;

        return ProjectFactory.CreateModelFromEntity(updatedEntity);
    }
}
