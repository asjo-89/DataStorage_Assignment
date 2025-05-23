using Business.Interfaces;
using Business.Models;
using Data.Contexts;
using Data.Interfaces;

namespace WebApi.StartService;

public static class StartUp
{
    public static void AddStatusesOnStartup(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        if (!context.StatusInformation.Any())
        {
            var started = new StatusInformation { StatusName = "Not started" };
            var ongoing = new StatusInformation { StatusName = "Ongoing" };
            var completed = new StatusInformation { StatusName = "Completed" };

            context.SaveChanges();
        }
    }
}
