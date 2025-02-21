using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Services;

public class ProjectService 
    : BaseService<Project, ProjectEntity, ProjectRegForm>, IProjectService
{
    protected readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
        : base(projectRepository,
            ProjectFactory.Create,
            ProjectFactory.Create,
            ProjectFactory.Create)
    {
        _projectRepository = projectRepository;
    }

    public override async Task<Project> CreateAsync(ProjectRegForm dto)
    {
        if (dto == null) return null!;
        if (await _repository.AlreadyExists(p => p.ProjectTitle == dto.ProjectTitle))
        {
            Debug.WriteLine("A project with the same title already exists.");
            return null!;
        }

        try
        {
            await _repository.BeginTransactionAsync();

            ProjectEntity? entity = ProjectFactory.Create(dto);
            entity = await _repository.CreateAsync(entity);
            if (entity == null!) return null!;

            await _repository.SaveChangesAsync();
            await _repository.CommitTransactionAsync();

            ProjectEntity newEntity = await _projectRepository.GetWithDetailsAsync(x => x.Id == entity.Id);
            Project newProject = ProjectFactory.Create(entity);
            return newProject ?? null!;
        }
        catch (Exception ex)
        {
            await _repository.RollbackAsync();
            Debug.WriteLine($"Failed to create: {ex.Message}");
            return null!;
        }

    }

    public override async Task<IEnumerable<Project>> GetAllAsync()
    {
        var entities = await _projectRepository.GetAllWithDetailsAsync();
        var projects = entities.Select(p => ProjectFactory.Create(p)).ToList();
        return projects ?? [];
    }

    public async Task<Project> GetOneAsync(int id)
    {
        if (id == 0) return null!;

        ProjectEntity entity = await _projectRepository.GetWithDetailsAsync(x => x.Id == id);
        if (entity == null) return null!;

        Project project = ProjectFactory.Create(entity);
        return project ?? null!;
    }

    public async Task<Project> UpdateProjectAsync(Project project)
    {
        if (project == null) return null!;
        ProjectEntity updatedEntity = ProjectFactory.Create(project);

        Console.WriteLine(updatedEntity);

        try
        {
            await _repository.BeginTransactionAsync();

            updatedEntity = _repository.UpdateAsync(updatedEntity);
            if (updatedEntity == null) return null!;

            await _repository.SaveChangesAsync();
            await _repository.CommitTransactionAsync();

            updatedEntity = await _projectRepository.GetWithDetailsAsync(x => x.Id == project.Id);
            Project updatedProject = ProjectFactory.Create(updatedEntity);
            return updatedProject ?? null!;
        }
        catch (Exception ex)
        {
            await _repository.RollbackAsync();
            Debug.WriteLine($"Failed to update project: {ex.Message}");
            return null!;
        }
    }

    public override async Task<Project> GetOneAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        ProjectEntity? entity = await _repository.GetOneAsync(expression);
        Project model = ProjectFactory.CreateForDelete(entity);

        return model ?? null!;
    }
}
