using BookingSystem.dal.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.dal
{
    public class BookingSystemDbContext : DbContext
    {
        public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options) : base(options) { }

        public DbSet<Buses> Buses { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Planes> Planes { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Trains> Trains { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
        public DbSet<TrainSchedules> TrainSchedules { get; set; }
        public DbSet<BusSchedules> BusSchedules { get; set; }
        public DbSet<PlaneSchedules> PlaneSchedules { get; set; }
        public DbSet<Routes> Routes { get; set; }


    }
}
