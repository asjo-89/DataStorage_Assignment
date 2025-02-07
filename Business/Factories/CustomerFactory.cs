using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class CustomerFactory
    {
        public static CustomerDto Create() => new();


        public static CustomerEntity CreateEntityFromDto(CustomerDto dto) => new()
        {
            CustomerName = dto.CustomerName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email!
        };

        public static CustomerEntity CreateEntityFromModel(Customer model) => new()
        {
            Id = model.Id,
            CustomerName = model.CustomerName,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email!
        };

        public static Customer CreateModelFromEntity(CustomerEntity entity) => new()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
            Projects = entity.Projects?.Select(p => new Project
            {
                Id = p.Id,
                Title = p.ProjectTitle,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Employee = $"{p.Employee.FirstName} {p.Employee.LastName}"
            }).ToList()
        };
    }
}
