using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static ServiceRegForm Create() => new();

    public static ServiceEntity Create(ServiceRegForm dto) => new()
    {
        ServiceName = dto.ServiceName,
        Price = dto.Price,
        Unit = dto.Unit
    };

    public static Service Create(ServiceEntity entity) => new()
    {
        Id = entity.Id,
        ServiceName = entity.ServiceName,
        Price = entity.Price,
        Unit = entity.Unit
    };
    public static ServiceEntity Create(Service model) => new()
    {
        Id = model.Id,
        ServiceName = model.ServiceName,
        Price = model.Price,
        Unit = model.Unit
    };
}





//using Business.Dtos;
//using Business.Models;
//using Data.Entities;

//namespace Business.Factories;

//public class ServiceFactory
//{
//    public static ServiceRegForm Create() => new();

//    public static ServiceEntity CreateEntityFromDto(ServiceRegForm dto) => new()
//    {
//        ServiceName = dto.ServiceName,
//        Price = dto.Price,
//        Unit = dto.Unit
//    };

//    public static Service CreateModelFromEntity(ServiceEntity entity) => new()
//    {
//        Id = entity.Id,
//        ServiceName = entity.ServiceName,
//        Price = entity.Price,
//        Unit = entity.Unit
//    };
//    public static ServiceEntity CreateEntityFromModel(Service model) => new()
//    {
//        Id = model.Id,
//        ServiceName = model.ServiceName,
//        Price = model.Price,
//        Unit = model.Unit
//    };

//    public static ServiceRegForm CreateDtoFromModel(Service model) => new()
//    {
//        Id = model.Id,
//        ServiceName = model.ServiceName,
//        Price = model.Price,
//        Unit = model.Unit
//    };
//}
