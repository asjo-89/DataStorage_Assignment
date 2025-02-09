using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IEmployeeRepository : IBaseRepository<EmployeeEntity>
{
    Task<ICollection<EmployeeEntity>> GetEmployeesWithDetailsAsync();
    Task<EmployeeEntity> GetEmployeeWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> expression);
}
