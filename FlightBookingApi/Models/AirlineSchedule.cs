using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class AirlineSchedule
    {
        public Guid Id { get; set; }
        public string FlightNo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Decimal NonBusinessClassPrice { get; set; }
        public Decimal BusinessClassPrice { get; set; }
        public long TotalSeats { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Airline Airline { get; set; }

    }
}
