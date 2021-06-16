using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.Interfaces
{
    public class AirlineServicesImpl:  IAirlineServices
    {
        public FlightBookingDbContext _context;
        public AirlineServicesImpl(FlightBookingDbContext context)
        {
            _context = context;
        }

        public Airline AddAirline(Airline airline)
        {
            airline.Id = Guid.NewGuid();
            _context.Airlines.Add(airline);
            _context.SaveChanges();
            return airline;
        }

        public Airline GetAirlineById(Guid id)
        {
            return _context.Airlines.FirstOrDefault(x => x.Id == id);
        }

        public List<Airline> GetAirlines()
        {
            return _context.Airlines.ToList();
        }
    }
}
