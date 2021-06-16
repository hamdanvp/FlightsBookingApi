using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class ScheduleSeats
    {
        public string Id { get; set; }
        public string SeatName { get; set; }
        public AirlineSchedule AirlineSchedule { get; set; }
        public bool IsBooked { get; set; } = false;
    }
}
