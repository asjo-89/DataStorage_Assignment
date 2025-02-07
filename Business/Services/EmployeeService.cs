using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class EmployeeService(IBaseRepository<EmployeeEntity> repository) 
    : BaseService<Employee, EmployeeEntity, EmployeeDto>(repository, EmployeeFactory.CreateModelFromEntity, EmployeeFactory.CreateEntityFromModel, EmployeeFactory.CreateEntityFromDto), IEmployeeService
{   
    public async Task<Employee> GetEmployeeWithDetailsAsync(string field, string value)
    {
        var expression = CreateExpressionAsync(field, value);
        var entity = await _repository.GetOneAsync(expression);
        var customer = EmployeeFactory.CreateModelFromEntity(entity);

        return customer;
    }
}
