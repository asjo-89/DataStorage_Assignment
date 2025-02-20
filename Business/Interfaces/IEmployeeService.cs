using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IEmployeeService : IBaseService<Employee, EmployeeEntity, EmployeeRegForm>
{
    //Task<Employee> GetEmployeeWithDetailsAsync(string field, string value);
    Task<Employee> GetEmployeeAsync(int id);
    Task<ICollection<Employee>> GetEmployeesWithDetailsAsync(string field, string value);
    Task<Employee> UpdateEmployeeAsync(int id, Employee model);


}
