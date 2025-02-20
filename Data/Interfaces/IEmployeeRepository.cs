using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IEmployeeRepository : IBaseRepository<EmployeeEntity>
{

    Task<EmployeeEntity> GetWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> expression);
    Task<ICollection<EmployeeEntity>> GetAllWithDetailsAsync();


    //Task<EmployeeEntity> GetEmployeeWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> expression);
    //Task<ICollection<EmployeeEntity>> GetEmployeesWithDetailsAsync();
    //Task<ICollection<EmployeeEntity>> GetEmployeesWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> expression);
}
