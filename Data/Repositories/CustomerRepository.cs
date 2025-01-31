using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CustomerRepository(DbContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
}
