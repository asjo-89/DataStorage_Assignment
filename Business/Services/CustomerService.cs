using Business.Dtos;
using Business.Errors;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerService(IBaseRepository<CustomerEntity> repository)
    : BaseService<Customer, CustomerEntity, CustomerRegForm>(repository, CustomerFactory.CreateModelFromEntity, CustomerFactory.CreateEntityFromModel, CustomerFactory.CreateEntityFromDto), ICustomerService
{


    public async Task<Customer> GetCustomerWithDetailsAsync(string field, string value)
    {
        var expression = CreateExpressionAsync(field, value);
        var entity = await _repository.GetOneAsync(expression);
        if (entity == null) return null!;

        var customer = CustomerFactory.CreateModelFromEntity(entity);

        return customer;
    }

    public override async Task<Customer> CreateAsync(CustomerRegForm dto)
    {
        if (await _repository.ExistsAsync(c => c.CustomerName == dto.CustomerName))
        {
            Debug.WriteLine("A customer with the same name already exists.");
            return null!;
        }

        if (await _repository.ExistsAsync(c => c.PhoneNumber == dto.PhoneNumber))
        {
            Debug.WriteLine("A customer with the same phone number already exists.");
            return null!;
        }

        if (await _repository.ExistsAsync(c => c.Email == dto.Email))
        {
            Debug.WriteLine("A customer with the same email already exists.");
            return null!;
        }

        Customer customer = await base.CreateAsync(dto);
        return customer ?? null!;
    }
}
