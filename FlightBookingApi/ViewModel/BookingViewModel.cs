using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.ViewModel
{
    public class BookingViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public List<ScheduleViewModel> Schedules { get; set; }
        public decimal DiscountAmount { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}
