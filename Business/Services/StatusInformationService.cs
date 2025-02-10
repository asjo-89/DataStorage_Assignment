using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class StatusInformationService(IBaseRepository<StatusInformationEntity> repository) 
    : BaseService<StatusInformation, StatusInformationEntity, StatusInformationDto>(repository,
        StatusInformationFactory.CreateModelFromEntity, 
        StatusInformationFactory.CreateEntityFromModel,
        StatusInformationFactory.CreateEntityFromDto), 
    IStatusInformationService
{
}
