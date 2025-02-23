using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class StatusInformationFactory
{
    public static StatusInformationRegForm Create() => new();

    public static StatusInformationEntity Create(StatusInformationRegForm dto) => new()
    {
        StatusName = dto.StatusName
    };

    public static StatusInformation Create(StatusInformationEntity entity) => new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };
    public static StatusInformationEntity Create(StatusInformation model) => new()
    {
        Id = model.Id,
        StatusName = model.StatusName
    };
}


