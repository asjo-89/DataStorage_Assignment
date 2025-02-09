using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static ServiceDto Create() => new();

    public static ServiceEntity CreateEntityFromDto(ServiceDto dto) => new()
    {
        ServiceName = dto.ServiceName,
        Price = dto.Price,
        Unit = dto.Unit
    };

    public static Service CreateModelFromEntity(ServiceEntity entity) => new()
    {
        Id = entity.Id,
        ServiceName = entity.ServiceName,
        Price = entity.Price,
        Unit = entity.Unit
    };
    public static ServiceEntity CreateEntityFromModel(Service model) => new()
    {
        Id = model.Id,
        ServiceName = model.ServiceName,
        Price = model.Price,
        Unit = model.Unit
    };

    public static ServiceDto CreateDtoFromModel(Service model) => new()
    {
        Id = model.Id,
        ServiceName = model.ServiceName,
        Price = model.Price,
        Unit = model.Unit
    };
}
