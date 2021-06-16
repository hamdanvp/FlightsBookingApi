using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.ViewModel
{
    public class ScheduleViewModel
    {
        public string ScheduleId { get; set; }
        public bool IsBusinesClass { get; set; } = false;
        public string ClassType { get; set; }
        public decimal BookingPrice { get; set; }
        public string MealType { get; set; }
    }
}
