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
    public class ScheduleController : ControllerBase
    {
        private IAirlineScheduleServices _services;
        public ScheduleController(IAirlineScheduleServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetSchedules([FromQuery]SearchModel searchModel)
        {
            return Ok(_services.GetSchedules(searchModel));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetScheduleById(Guid id)
        {
            AirlineSchedule airlineSchedule = _services.GetScheduleById(id);
            if (airlineSchedule != null)
            {
                return Ok(airlineSchedule);
            }
            return NotFound("Schedule id:" + id + " not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddSchedule(AirlineSchedule airlineSchedule)
        {
            _services.AddSchedule(airlineSchedule);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + "/" + airlineSchedule.Id, airlineSchedule);
        }
    }
}
