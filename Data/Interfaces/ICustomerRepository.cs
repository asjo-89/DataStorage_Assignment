using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface ICustomerRepository : IBaseRepository<CustomerEntity>
{
    Task<CustomerEntity> GetCustomerWithDetails(Expression<Func<CustomerEntity, bool>> expression);
}
