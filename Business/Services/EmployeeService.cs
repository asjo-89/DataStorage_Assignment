using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class EmployeeService(IBaseRepository<EmployeeEntity> repository) : BaseService<Employee, EmployeeEntity, EmployeeDto>(repository, EmployeeFactory.CreateModelFromEntity, EmployeeFactory.CreateEntityFromModel, EmployeeFactory.CreateEntityFromDto), IEmployeeService
{
    //public async Task<Employee> CreateAsync(EmployeeDto dto)
    //{
    //    if (dto == null) return null!;

    //    Employee employee = EmployeeFactory.CreateModelFromDto(dto);

    //    return await _repository.CreateAsync(employee);
    //}
    public Task<Employee> CreateAsync(EmployeeDto dto)
    {
        throw new NotImplementedException();
    }
}
