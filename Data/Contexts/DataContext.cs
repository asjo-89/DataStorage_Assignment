using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UnitEntity> Units { get; set; }
    public DbSet<StatusInformationEntity> StatusInformation { get; set; }
    public DbSet<EmailAddressEntity> EmailAddresses { get; set; }
    public DbSet<PhoneNumberEntity> PhoneNumbers { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
}
