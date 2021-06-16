using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Interfaces;
using FlightBookingAPI.Models;
using FlightBookingAPI.ViewModel;

namespace FlightBookingAPI.Controllers
{
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingServices _services;
        public BookingController(IBookingServices services)
        {
            _services = services;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetBookings([FromQuery] SearchModel searchModel)
        {
            return Ok(_services.GetBookings(searchModel));
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public IActionResult GetBookingById(Guid id)
        {
            Booking booking = _services.GetBookingById(id);
            if (booking != null)
            {
                return Ok(booking);
            }

            return NotFound("Booking id:" + id + " is not found.");
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult AddBooking([FromBody] BookingViewModel booking)
        {
            List<Booking> bookings= _services.AddBooking(booking);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path, bookings);

        }

        [Route("api/[controller]/GetPassengersByBookingId/{id}")]
        [HttpGet]
        public IActionResult GetPassengersByBookingId(Guid id)
        {
            return Ok(_services.GetPassengersByBookingId(id));
        }

        [Route("api/[controller]/CancelBookingById/{id}")]
        [HttpPut]
        public IActionResult CancelBookingById(Guid id)
        {
            Booking booking = _services.CancelBookingById(id);
            if (booking != null)
            {
                return Ok(booking);
            }

            return NotFound("Booking id:" + id + " is not found.");
        }

    }
}
