using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;
using FlightBookingAPI.Interfaces;

namespace FlightBookingAPI.Controllers
{
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private IAirlineServices _airlineServices;
        public AirlineController(IAirlineServices airlineServices)
        {
            _airlineServices = airlineServices;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAirlines()
        {
            return Ok(_airlineServices.GetAirlines());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAirlinesById(Guid id)
        {
            Airline airline = _airlineServices.GetAirlineById(id);
            if (airline != null)
            {
                return Ok(airline);
            }
            return NotFound("Airline id:" + id + " not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddAirline([FromBody] Airline airline)
        {
            _airlineServices.AddAirline(airline);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + "/" + airline.Id, airline);
        }
    }
}
