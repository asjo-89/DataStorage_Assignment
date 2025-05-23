using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

//namespace Data.Contexts;


//public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
//{
//    public DataContext CreateDbContext(string[] args)
//    {
//        var config = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: true)
//            .AddUserSecrets<DataContextFactory>()
//            .Build();

//        var connectionString = config.GetConnectionString("DefaultConnection");

//        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
//        optionsBuilder.UseSqlServer(connectionString);

//        return new DataContext(optionsBuilder.Options);
//    }
//}
