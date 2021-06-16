using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.Interfaces
{
    public interface IAirlineScheduleServices
    {
        AirlineSchedule AddSchedule(AirlineSchedule schedule);
        AirlineSchedule GetScheduleById(Guid id);
        List<AirlineSchedule> GetSchedules(SearchModel searchModel);
    }
}
