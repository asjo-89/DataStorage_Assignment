using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IEmployeeService : IBaseService<Employee, EmployeeEntity, EmployeeRegForm>
{
}
