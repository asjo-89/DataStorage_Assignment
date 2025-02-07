using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UnitEntity> Units { get; set; }
    public DbSet<StatusInformationEntity> StatusInformation { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd() 
                  .HasAnnotation("SqlServer:Identity", "1, 1");
        });
        modelBuilder.Entity<EmployeeEntity>(entity =>
        {
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasAnnotation("SqlServer:Identity", "1, 1");
        });
        modelBuilder.Entity<ProjectEntity>(entity =>
        {
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasAnnotation("SqlServer:Identity", "1, 1");
        });
        modelBuilder.Entity<RoleEntity>(entity =>
        {
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasAnnotation("SqlServer:Identity", "1, 1");
        });
        modelBuilder.Entity<StatusInformationEntity>(entity =>
        {
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasAnnotation("SqlServer:Identity", "1, 1");
        });
        modelBuilder.Entity<ServiceEntity>(entity =>
        {
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasAnnotation("SqlServer:Identity", "1, 1");
        });
        modelBuilder.Entity<UnitEntity>(entity =>
        {
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasAnnotation("SqlServer:Identity", "1, 1");
        });
        base.OnModelCreating(modelBuilder);
    }
}
