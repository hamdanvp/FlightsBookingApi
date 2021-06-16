using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string PNR { get; set; }
        public decimal OrginalAmount { get; set; }
        public decimal BookingAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public string MealType { get; set; }
        public string ClassType { get; set; }
        public int BookedSeats { get; set; }
        public bool IsCancelled { get; set; } = false;
        public AirlineSchedule AirlineSchedule { get; set; }
        public User User { get; set; }
    }
}
