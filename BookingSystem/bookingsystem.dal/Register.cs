using BookingSystem.dal.Implement;
using BookingSystem.dal.Interface;
using BookingSystem.dal.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.dal
{
    public static class Register
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILocationRepository, LocationRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            serviceCollection.AddScoped<IBusSchedulesRepository, BusSchedulesRepository>();
            serviceCollection.AddScoped<ITrainSchedulesRepository, TrainSchedulesRepository>();
            serviceCollection.AddScoped<IPlanesRepository, PlanesRepository>();
            serviceCollection.AddScoped<ITrainsRepository, TrainsRepository>();
            serviceCollection.AddScoped<IBusesRepository, BusesRepository>();
            serviceCollection.AddScoped<IPlaneSchedulesRepository, PlaneSchedulesRepository>();
            serviceCollection.AddScoped<ITicketsRepository, TicketsRepository>();
            serviceCollection.AddScoped<IRoutesRepository, RoutesRepository>();

            var serviceProvider = serviceCollection
            .AddDbContext<BookingSystemDbContext>(options => options.UseInMemoryDatabase("BookingSystem"))
            .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BookingSystemDbContext>();
                var dataSeeder = new DataSeeder(dbContext);
                dataSeeder.SeedLocation();
                dataSeeder.SeedTrains();
                dataSeeder.SeedBuses();
                dataSeeder.SeedPlanes();
                dataSeeder.SeedTicketType();
                dataSeeder.SeedTrainSchedules();
                dataSeeder.SeedPlaneSchedules();
                dataSeeder.SeedBusSchedules();
                dataSeeder.SeedRoutes();
            }
        }
    }
}