﻿using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class StatusInformationService(IBaseRepository<StatusInformationEntity> repository) 
    : BaseService<StatusInformation, StatusInformationEntity, StatusInformationRegForm>(repository,
        StatusInformationFactory.Create, 
        StatusInformationFactory.Create,
        StatusInformationFactory.Create), 
    IStatusInformationService
{
}
