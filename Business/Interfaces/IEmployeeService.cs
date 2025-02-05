using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IEmployeeService : IBaseService<Employee, EmployeeEntity>
{
    Task<Employee> CreateAsync(EmployeeDto dto);
}
