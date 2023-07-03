using BookingSystem.dal;
using BookingSystem.Services.Implement;
using BookingSystem.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Services
{
    public class Registration
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILocationService, LocationService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ITicketTypeService, TicketTypeService>();
            serviceCollection.AddScoped<ITicketService, TicketService>();
            serviceCollection.AddScoped<IScheduleService, ScheduleService>();
            serviceCollection.AddScoped<IRouteService, RouteService>();
            Register.ConfigureServices(serviceCollection);
        }
    }
}