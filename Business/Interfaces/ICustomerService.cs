using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface ICustomerService : IBaseService<Customer, CustomerEntity>
{
    Task<Customer> CreateAsync(CustomerDto dto);
    Task<Customer> GetByCustomerNameAsync(string customerName); 
    Task<Customer> GetByEmailAsync(string email);
}
