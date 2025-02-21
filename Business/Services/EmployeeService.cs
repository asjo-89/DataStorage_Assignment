using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

namespace Business.Services;

public class EmployeeService
    : BaseService<Employee, EmployeeEntity, EmployeeRegForm>, IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository) 
        : base(employeeRepository, 
            EmployeeFactory.Create, 
            EmployeeFactory.Create, 
            EmployeeFactory.Create)
    {
        _employeeRepository = employeeRepository;
    }

    

    public override async Task<Employee> CreateAsync(EmployeeRegForm dto)
    {
        if (dto == null) return null!;
        if (await _repository.AlreadyExists(e => e.FirstName == dto.FirstName && e.LastName == dto.LastName))
        {
            Debug.WriteLine("An employee with the same name already exists.");
            return null!;
        }

        try
        {
            await _repository.BeginTransactionAsync();

            EmployeeEntity entity = EmployeeFactory.Create(dto);
            EmployeeEntity entry = await _repository.CreateAsync(entity);
            if (entry == null) return null!;

            await _repository.SaveChangesAsync();
            await _repository.CommitTransactionAsync();

            Employee employee = EmployeeFactory.Create(entity);
            return employee ?? null!;
        }
        catch (Exception ex)
        {
            await _repository.RollbackAsync();
            Debug.WriteLine($"Failed to create: {ex.Message}");
            return null!;
        }
    }

    public override async Task<IEnumerable<Employee>> GetAllAsync()
    {
        IEnumerable<EmployeeEntity> entities = await _employeeRepository.GetAllWithDetailsAsync();

        List<Employee> employees = entities.Select(e => EmployeeFactory.Create(e)).ToList();
        return employees ?? [];
    }

    public  async Task<Employee> GetOneAsync(int id)
    {
        EmployeeEntity entity = await _employeeRepository.GetWithDetailsAsync(x => x.Id == id);
        if (entity == null) return null!;
        Employee employee = EmployeeFactory.Create(entity);
        return employee ?? null!;
    }

    //public async Task<Employee> UpdateEmployeeAsync(Employee model)
    //{
    //    try
    //    {
    //        if (model != null)
    //        {
    //            EmployeeEntity? entity = EmployeeFactory.Create(model);
    //            EmployeeEntity? updatedEntity = _repository.UpdateAsync(entity);
    //            return EmployeeFactory.Create(updatedEntity!) ?? null!;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Failed to update :: {ex.Message}");
    //    }
    //    return null!;
    //}
}
