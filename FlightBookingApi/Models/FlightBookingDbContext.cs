using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingAPI.Models
{
    public class FlightBookingDbContext : DbContext
    {
        public FlightBookingDbContext(DbContextOptions<FlightBookingDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<AirlineSchedule> AirlineSchedules { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<ScheduleSeats> ScheduleSeats { get; set; }
    }
}
