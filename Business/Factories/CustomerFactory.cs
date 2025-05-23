

using Business.Dtos;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Factories
{
    public static class CustomerFactory
    {
        public static CustomerRegForm Create() => new();


        public static CustomerEntity CreateEntityFromDto(CustomerRegForm dto) => new()
        {
            CustomerName = dto.CustomerName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email
        };

        public static CustomerEntity Create(Customer model) => new()
        {
            Id = model.Id,
            CustomerName = model.CustomerName,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email
        };

        public static Customer Create(CustomerEntity entity) => new()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
            Projects = entity.Projects.Select(p => new Project
            {
                Id = p.Id,
                ProjectTitle = p.ProjectTitle,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                EmployeeId = p.EmployeeId,
                Employee = new Employee()
                {
                    Id = p.EmployeeId,
                    FirstName = p.Employee.FirstName,
                    LastName = p.Employee.LastName
                },
                StatusInformationId = p.StatusInformationId
            }).ToList()
        };
    }
}

