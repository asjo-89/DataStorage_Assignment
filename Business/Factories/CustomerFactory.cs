using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class CustomerFactory
    {
        public static CustomerDto Create() => new();

        public static Customer CreateModelFromDto(CustomerDto dto) => new()
        {
            Id = dto.Id,
            CustomerName = dto.CustomerName,
            PhoneNumbers = dto.PhoneNumbers.Select(p => new PhoneNumber
            {
                Phone = p.PhoneNumber
            }).ToList() ?? [],
            Emails = dto.Emails?.Select(e => new EmailAddress
            {
                Email = e.Email
            }).ToList() ?? []
        };

        public static CustomerDto CreateDtoFromModel(Customer model) => new()
        {
            CustomerName = model.CustomerName,
            PhoneNumbers = model.PhoneNumbers.Select(p => new PhoneNumberDto
            {
                PhoneNumber = p.Phone
            }).ToList() ?? [],
            Emails = model.Emails?.Select(e => new EmailDto
            {
                Email = e.Email
            }).ToList() ?? []
        };


        public static CustomerEntity CreateEntityFromModel(Customer model) => new()
        {
            Id = model.Id,
            CustomerName = model.CustomerName,
            PhoneNumbers = model.PhoneNumbers.Select(p => new PhoneNumberEntity
            {
                CustomerId = model.Id,
                PhoneNumber = p.Phone
            }).ToList() ?? [],
            EmailAddresses = model.Emails?.Select(e => new EmailAddressEntity
            {
                CustomerId = model.Id,
                EmailAddress = e.Email
            }).ToList() ?? []
        };

        public static Customer CreateModelFromEntity(CustomerEntity entity) => new()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
            PhoneNumbers = entity.PhoneNumbers.Select(p => new PhoneNumber
            {
                Phone = p.PhoneNumber
            }).ToList() ?? [],
            Emails = entity.EmailAddresses?.Select(e => new EmailAddress
            {
                Email = e.EmailAddress
            }).ToList() ?? []
        };
    }
}
