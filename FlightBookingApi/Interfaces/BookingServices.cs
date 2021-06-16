using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;
using FlightBookingAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using FlightBookingAPI.Common;

namespace FlightBookingAPI.Interfaces
{
    public class BookingServices : IBookingServices
    {
        private FlightBookingDbContext _context;
        private IAirlineScheduleServices _scheduleServices;
        public BookingServices(FlightBookingDbContext context,IAirlineScheduleServices scheduleServices)
        {
            _context = context;
            _scheduleServices = scheduleServices;
        }
        public List<Booking> AddBooking(BookingViewModel booking)
        {
            List<Booking> bookings = new List<Booking>();
            foreach (ScheduleViewModel schedule in booking.Schedules)
            {
                if (!string.IsNullOrEmpty(schedule.ScheduleId)) {
                    Booking content = new Booking();

                    content.Id = Guid.NewGuid();
                    AirlineSchedule airlineSchedule = _scheduleServices.GetScheduleById(Guid.Parse(schedule.ScheduleId));
                    content.AirlineSchedule = airlineSchedule;
                    content.BookedSeats = booking.Passengers.Count;
                    content.OrginalAmount = (schedule.IsBusinesClass ? airlineSchedule.BusinessClassPrice : airlineSchedule.BusinessClassPrice)* content.BookedSeats;
                    content.DiscountAmount = booking.DiscountAmount / booking.Schedules.Count;
                    content.BookingAmount = content.OrginalAmount - booking.DiscountAmount;
                    content.ClassType = schedule.ClassType;
                    content.Name = booking.Name;
                    content.ContactNumber = booking.ContactNumber;
                    content.ContactAddress = booking.ContactAddress;
                    content.User = _context.Users.Where(x => x.Id == Guid.Parse(booking.UserId)).FirstOrDefault();
                    content.IsCancelled = false;
                    content.PNR = Common.Common.GeneratePNR();
                    _context.Bookings.Add(content);
                    _context.SaveChanges();
                    AddPasengers(booking.Passengers, content);
                    bookings.Add(content);
                }
                
            }
            return bookings;
        }

        public List<Passenger> AddPasengers(List<Passenger> model,Booking booking)
        {
            List<Passenger> passengerList = new List<Passenger>();
            foreach (Passenger passenger in model) {
                passenger.Id = Guid.NewGuid().ToString();
                passenger.Booking = booking;
                _context.Passengers.Add(passenger);
                _context.SaveChanges();
                passengerList.Add(passenger);
            }
            return passengerList;
        }

        public List<Passenger> GetPassengersByBookingId(Guid bookingId)
        {
            return _context.Passengers
                                .Include(b => b.Booking)
                                .Where(p => p.Booking.Id == bookingId).ToList();
        }

        public Booking GetBookingById(Guid id)
        {
            return _context.Bookings
                    .Include(w => w.AirlineSchedule)
                        .ThenInclude(a => a.Airline)
                    .Include(u => u.User).Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Booking> GetBookings(SearchModel search)
        {
            List<Booking> result = new List<Booking>();
            if (search.UserId != null)
            {
                result = _context.Bookings
                            .Include(w => w.AirlineSchedule)
                                .ThenInclude(a=>a.Airline)
                            .Include(u => u.User).Where(x => x.User.Id == search.UserId).ToList();
            }
            else
            {
                result = _context.Bookings
                            .Include(w => w.AirlineSchedule)
                                .ThenInclude(a => a.Airline)
                            .Include(u => u.User).ToList();
            }

            if (search.IsCancelled != null)
            {
                result = result.Where(x => x.IsCancelled == search.IsCancelled).ToList();
            }

            if (search.StartDate != null)
            {
                DateTime startDate = search.StartDate ?? DateTime.Now;
                result = result.Where(x => x.AirlineSchedule.DepartureDate >= startDate).ToList();
            }

            if (search.EndDate != null)
            {
                DateTime EndDate = search.EndDate ?? DateTime.Now;
                result = result.Where(x => x.AirlineSchedule.DepartureDate <= EndDate).ToList();
            }

            return result;
        }

        public Booking CancelBookingById(Guid id)
        {
            Booking booking = GetBookingById(id);
            booking.IsCancelled = true;
            _context.Update(booking);
            _context.SaveChanges();
            return booking;
        }
    }
}
