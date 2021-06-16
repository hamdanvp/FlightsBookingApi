using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;
using FlightBookingAPI.ViewModel;

namespace FlightBookingAPI.Interfaces
{
    public interface IBookingServices
    {
        List<Booking> AddBooking(BookingViewModel booking);
        List<Booking> GetBookings(SearchModel search);
        Booking GetBookingById(Guid id);
        Booking CancelBookingById(Guid id);
        List<Passenger> GetPassengersByBookingId(Guid bookingId);
    }
}
