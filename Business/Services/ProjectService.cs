using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IBaseRepository<ProjectEntity> repository) : BaseService<Project, ProjectEntity, ProjectDto>(repository, ProjectFactory.CreateModelFromEntity, ProjectFactory.CreateEntityFromModel, ProjectFactory.CreateEntityFromDto), IProjectService
{
}
