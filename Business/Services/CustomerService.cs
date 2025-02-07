using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerService(IBaseRepository<CustomerEntity> repository) 
    : BaseService<Customer, CustomerEntity, CustomerDto>(repository, CustomerFactory.CreateModelFromEntity, CustomerFactory.CreateEntityFromModel, CustomerFactory.CreateEntityFromDto), ICustomerService
{
    public async Task<Customer> GetCustomerWithDetailsAsync(string field, string value)
    {
        var expression = CreateExpressionAsync(field, value);
        var entity = await _repository.GetOneAsync(expression);
        var customer = CustomerFactory.CreateModelFromEntity(entity);

        return customer;
    }
}
