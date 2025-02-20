using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface ICustomerRepository : IBaseRepository<CustomerEntity>
{
    Task<CustomerEntity> GetWithDetailsAsync(Expression<Func<CustomerEntity, bool>> expression);
    Task<IEnumerable<CustomerEntity>> GetAllWithDetailsAsync();




    //Task<CustomerEntity> GetCustomerWithDetailsAsync(Expression<Func<CustomerEntity, bool>> expression);
}
