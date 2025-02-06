using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(IBaseRepository<CustomerEntity> repository) 
    : BaseService<Customer, CustomerEntity, CustomerDto>(repository, CustomerFactory.CreateModelFromEntity, CustomerFactory.CreateEntityFromModel, CustomerFactory.CreateEntityFromDto), ICustomerService
{
    public async Task<Customer> GetByCustomerNameAsync(string customerName)
    {
        if (!string.IsNullOrWhiteSpace(customerName)) return null!;

        CustomerEntity entity = await _repository.GetByPropertyAsync(x => x.CustomerName == customerName);
        return entity != null ? CustomerFactory.CreateModelFromEntity(entity) : null!;
    }

    public async Task<Customer> GetByEmailAsync(string email)
    {
        if (!string.IsNullOrWhiteSpace(email)) return null!;

        CustomerEntity entity = await _repository.GetByPropertyAsync(x => x.Email == email);
        return entity != null ? CustomerFactory.CreateModelFromEntity(entity) : null!;
    }
}
