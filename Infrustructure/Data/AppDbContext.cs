using Microsoft.EntityFrameworkCore;
using System;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //بين كيان الحجز و كيان الزائر one-to-one علاقة
            modelBuilder.Entity<Booking>().HasOne<Guest>().WithOne().HasForeignKey(dependentEntityType: typeof(Booking), "GuestId");


            //بين كيان الحجز و كيان الغرفة one-to-one علاقة
            modelBuilder.Entity<Booking>().HasOne<Room>().WithOne().HasForeignKey(dependentEntityType: typeof(Booking), "RoomId");




            modelBuilder.Entity<Guest>().HasData(SeedData.LoadGuests());
            modelBuilder.Entity<Hotel>().HasData(SeedData.LoadHotels());
            modelBuilder.Entity<RoomType>().HasData(SeedData.LoadRoomTypes());
            modelBuilder.Entity<Employee>().HasData(SeedData.LoadEmployees());
            modelBuilder.Entity<Room>().HasData(SeedData.LoadRooms());
            modelBuilder.Entity<Booking>().HasData(SeedData.LoadBookings());
            modelBuilder.Entity<Payment>().HasData(SeedData.LoadPayments());
        }
    }
}
