using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(IBaseRepository<CustomerEntity> repository) 
    : BaseService<Customer, CustomerEntity>(repository, CustomerFactory.CreateModelFromEntity, CustomerFactory.CreateEntityFromModel), ICustomerService
{
    public async Task<Customer> CreateAsync(CustomerDto dto)
    {
        if (dto == null) return null!;

        CustomerEntity customer = CustomerFactory.CreateEntityFromDto(dto);
        CustomerEntity createdCustomer = await _repository.CreateAsync(customer);
        return CustomerFactory.CreateModelFromEntity(createdCustomer);
    }

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
