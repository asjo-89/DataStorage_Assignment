using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IStatusInformationService : IBaseService<StatusInformation, StatusInformationEntity, StatusInformationRegForm>
{
}
