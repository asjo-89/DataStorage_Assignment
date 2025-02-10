using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class StatusInformationFactory
{
    public static StatusInformationDto Create() => new();

    public static StatusInformationEntity CreateEntityFromDto(StatusInformationDto dto) => new()
    {
        StatusName = dto.StatusName
    };

    public static StatusInformation CreateModelFromEntity(StatusInformationEntity entity) => new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };
    public static StatusInformationEntity CreateEntityFromModel(StatusInformation model) => new()
    {
        Id = model.Id,
        StatusName = model.StatusName
    };

    public static StatusInformationDto CreateDtoFromModel(StatusInformation model) => new()
    {
        Id = model.Id,
        StatusName = model.StatusName
    };
}
