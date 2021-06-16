using FlightBookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Interfaces
{
    public class AirlineScheduleServices : IAirlineScheduleServices
    {
        public FlightBookingDbContext _context;
        public AirlineScheduleServices(FlightBookingDbContext context)
        {
            _context = context;
        }
        public AirlineSchedule AddSchedule(AirlineSchedule schedule)
        {
            schedule.Id = Guid.NewGuid();
            Airline airline = _context.Airlines.FirstOrDefault(x => x.Id == schedule.Airline.Id);
            schedule.Airline = airline;
            _context.AirlineSchedules.Add(schedule);
            _context.SaveChanges();
            return schedule;
        }

        public AirlineSchedule GetScheduleById(Guid id)
        {
            return _context.AirlineSchedules
                    .Include(w=>w.Airline).FirstOrDefault(x => x.Id == id);
        }

        public List<AirlineSchedule> GetSchedules(SearchModel searchModel)
        {
            List<AirlineSchedule> result = new List<AirlineSchedule>();
            if(!string.IsNullOrEmpty(searchModel.FromLocation) && !string.IsNullOrEmpty(searchModel.ToLocation))
            {
                result = _context.AirlineSchedules
                            .Include(w => w.Airline)
                            .Where(x => x.From == searchModel.FromLocation && x.To == searchModel.ToLocation).ToList();
            }
            else if (searchModel.IsAdmin)
            {
                result = _context.AirlineSchedules
                            .Include(w => w.Airline).ToList();
            }

            if (!string.IsNullOrEmpty(searchModel.AirlineName))
            {
                result = result.Where(x => x.Airline.AirlineName == searchModel.AirlineName).ToList();
            }

            if (!string.IsNullOrEmpty(searchModel.InstrumentUsed))
            {
                result = result.Where(x => x.Airline.InstrumentUsed == searchModel.InstrumentUsed).ToList();
            }

            if (!string.IsNullOrEmpty(searchModel.FlightNo))
            {
                result = result.Where(x => x.FlightNo == searchModel.FlightNo).ToList();
            }

            if (searchModel.ScheduleDate != null)
            {
                DateTime scheduleDate = searchModel.ScheduleDate ?? DateTime.Now;
                result = result.Where(x => x.DepartureDate >= scheduleDate).ToList();
            }
            return result;
        }
    }
}
