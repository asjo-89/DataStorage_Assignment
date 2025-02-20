using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services
{
    public class ServicesService(IBaseRepository<ServiceEntity> repository)
        : BaseService<Service, ServiceEntity, ServiceRegForm>(repository, 
            ServiceFactory.CreateModelFromEntity, 
            ServiceFactory.CreateEntityFromModel, 
            ServiceFactory.CreateEntityFromDto), 
        IServicesService
    {
    }
}
