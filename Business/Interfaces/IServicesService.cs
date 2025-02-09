﻿using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IServicesService : IBaseService<Service, ServiceEntity, ServiceDto>
    {
        //Task<Service> CreateServiceAsync(ServiceDto dto);
    }
}