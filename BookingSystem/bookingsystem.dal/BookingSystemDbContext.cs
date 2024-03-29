﻿using BookingSystem.dal.Entity;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Routes>()
            .HasOne(r => r.Source)
            .WithMany()
            .HasForeignKey(r => r.SourceId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Routes>()
                .HasOne(r => r.Destination)
                .WithMany()
                .HasForeignKey(r => r.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Tickets>()
            .HasOne(r => r.Source)
            .WithMany()
            .HasForeignKey(r => r.SourceId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tickets>()
                .HasOne(r => r.Destination)
                .WithMany()
                .HasForeignKey(r => r.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tickets>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Users>()
                .HasMany(u => u.Tickets)                // Users can have multiple Tickets
                .WithOne(t => t.User)                    // Ticket belongs to one User
                .HasForeignKey(t => t.UserId)            // Foreign key property in Tickets table
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
