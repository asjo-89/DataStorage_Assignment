using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static ServiceDto Create() => new();

    public static ServiceEntity CreateEntityFromDto(ServiceDto dto) => new()
    {
        ServiceName = dto.ServiceName
    };

    public static Service CreateModelFromEntity(ServiceEntity entity) => new()
    {
        Id = entity.Id,
        ServiceName = entity.ServiceName
    };
    public static ServiceEntity CreateEntityFromModel(Service model) => new()
    {
        Id = model.Id,
        ServiceName = model.ServiceName
    };

    public static ServiceDto CreateDtoFromModel(Service model) => new()
    {
        Id = model.Id,
        ServiceName = model.ServiceName
    };
}
