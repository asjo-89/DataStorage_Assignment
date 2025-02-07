using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface ICustomerService : IBaseService<Customer, CustomerEntity, CustomerDto>
{
    Task<Customer> GetCustomerWithDetailsAsync(string field, string value);
}
