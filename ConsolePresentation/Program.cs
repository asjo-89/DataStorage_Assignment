using ConsolePresentation;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static async Task Main(string[] args)
    {
        
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddUserSecrets<Program>()
            .Build();


        var connectionString = config.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string could not be loaded. Check your appsettings.json or user secrets.");
        }

        var services = new ServiceCollection()
            .AddDbContext<DataContext>(x => x.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information))
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IPhoneNumberRepository, PhoneNumberRepository>()
            .AddScoped<MenuService>()
            .BuildServiceProvider();

        var menu = services.GetRequiredService<MenuService>();
        menu.Run();

        
       




        //var repo = serviceProvider.GetRequiredService<CustomerRepository>();

        //CustomerEntity entity = new()
        //{
        //    Id = 1,
        //    CustomerName = "Test"
        //};


    }
}