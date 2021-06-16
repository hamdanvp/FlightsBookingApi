using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class SearchModel
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string AirlineName { get; set; }
        public string FlightNo { get; set; }
        public string InstrumentUsed { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool? IsCancelled { get; set; }
        public Guid? UserId { get; set; } = null;
        public DateTime? ScheduleDate { get; set; } = null;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;

    }
}
