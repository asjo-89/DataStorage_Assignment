using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerService(IBaseRepository<CustomerEntity> repository)
    : BaseService<Customer, CustomerEntity, CustomerRegForm>(repository, 
        CustomerFactory.CreateEntityFromDto, 
        CustomerFactory.Create, 
        CustomerFactory.Create), 
    ICustomerService
{


    public async Task<Customer> GetWithDetailsAsync(int id)
    {
        var entity = await _repository.GetOneAsync(x => x.Id == id);
        if (entity == null) return null!;

        var customer = CustomerFactory.Create(entity);

        return customer ?? null!;
    }

    public override async Task<Customer> CreateAsync(CustomerRegForm dto)
    {
        if (await _repository.AlreadyExists(c => c.CustomerName == dto.CustomerName))
        {
            Debug.WriteLine("A customer with the same name already exists.");
            return null!;
        }

        if (await _repository.AlreadyExists(c => c.PhoneNumber == dto.PhoneNumber))
        {
            Debug.WriteLine("A customer with the same phone number already exists.");
            return null!;
        }

        if (await _repository.AlreadyExists(c => c.Email == dto.Email))
        {
            Debug.WriteLine("A customer with the same email already exists.");
            return null!;
        }

        try
        {
            await _repository.BeginTransactionAsync();

            var entity = CustomerFactory.CreateEntityFromDto(dto);
        
            var newEntity = await _repository.CreateAsync(entity);

            if (newEntity == null)
                return null!;

            await _repository.SaveChangesAsync();
            await _repository.CommitTransactionAsync();

            return CustomerFactory.Create(entity) ?? null!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to create customer: \n{ex.Message}");
            return null!;
        }
    }
}
