using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Business.Services;

public class EmployeeService
    : BaseService<Employee, EmployeeEntity, EmployeeDto>, IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository) 
        : base(employeeRepository, 
            EmployeeFactory.CreateModelFromEntity, 
            EmployeeFactory.CreateEntityFromModel, 
            EmployeeFactory.CreateEntityFromDto)
    {
        _employeeRepository = employeeRepository;
    }

    

    public override async Task<Employee> CreateAsync(EmployeeDto dto)
    {
        if (await _repository.ExistsAsync(e => e.FirstName == dto.FirstName && e.LastName == dto.LastName))
        {
            Debug.WriteLine("An employee with the same name already exists.");
            return null!;
        }
        
        EmployeeEntity entity = await _repository.CreateAsync(EmployeeFactory.CreateEntityFromDto(dto));
        if (entity == null) return null!;

        EmployeeEntity newEntity = await _employeeRepository.GetEmployeeWithDetailsAsync(e => e.Id == entity.Id);

        Employee employee = EmployeeFactory.CreateModelFromEntity(entity);
        return employee ?? null!;
    }
    public override async Task<ICollection<Employee>> GetAllAsync()
    {
        ICollection<EmployeeEntity> entities = await _employeeRepository.GetEmployeesWithDetailsAsync();
        
        return entities.Select(e => EmployeeFactory.CreateModelFromEntity(e)).ToList();
    }

    public async Task<ICollection<Employee>> GetEmployeesWithDetailsAsync(string field, string value)
    {
        var expression = CreateExpressionAsync(field, value);
        ICollection<EmployeeEntity> entities = await _employeeRepository.GetEmployeesWithDetailsAsync(expression);

        var employees = entities.Select(EmployeeFactory.CreateModelFromEntity).ToList();
        return employees ?? [];
    }

    public async Task<Employee> UpdateEmployeeAsync(int id, Employee model)
    {
        try
        {
            if (model != null)
            {
                EmployeeEntity? entity = EmployeeFactory.CreateEntityFromModel(model);
                EmployeeEntity? updatedEntity = await _repository.UpdateAsync(id, entity);
                updatedEntity = await _employeeRepository.GetEmployeeWithDetailsAsync(e => e.Id == entity.Id);
                return EmployeeFactory.CreateModelFromEntity(updatedEntity!) ?? null!;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to update :: {ex.Message}");
        }
        return null!;
    }
}
