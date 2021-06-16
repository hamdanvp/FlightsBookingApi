using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.Interfaces
{
    public interface IAirlineServices
    {
        Airline AddAirline(Airline airline);
        List<Airline> GetAirlines();
        Airline GetAirlineById(Guid id);
    }
}
