using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services
{
    public class ServicesService
        : BaseService<Service, ServiceEntity, ServiceDto>, IServicesService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesService(IServiceRepository serviceRepository) 
            : base(serviceRepository,
                ServiceFactory.CreateModelFromEntity,
                ServiceFactory.CreateEntityFromModel,
                ServiceFactory.CreateEntityFromDto)
        {
            _serviceRepository = serviceRepository;
        }

        //public async Task<Service> CreateServiceAsync(ServiceDto dto)
        //{
        //    if (await _repository.ExistsAsync(r => r.ServiceName == dto.ServiceName))
        //    {
        //        Debug.WriteLine("An employee with the same name already exists.");
        //        return null!;
        //    }

        //    ServiceEntity entity = await _repository.CreateAsync(ServiceFactory.CreateEntityFromDto(dto));
        //    if (entity == null) return null!;

        //    ServiceEntity newService = await _serviceRepository.GetServiceWithUnit(s => s.Id == entity.Id);
        //    if (newService == null) return null!;

        //    return ServiceFactory.CreateModelFromEntity(newService) ?? null!;
        //}
    }
}
