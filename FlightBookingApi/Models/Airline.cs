using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class Airline
    {
        public Guid Id { get; set; }
        public string AirlineName { get; set; }
        public string InstrumentUsed { get; set; }
        public string LogoUrl { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
    }
}
