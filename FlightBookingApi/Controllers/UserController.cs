using FlightBookingAPI.Interfaces;
using FlightBookingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllUser()
        {
            return Ok(_userServices.GetAllUser());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetUserById(Guid id)
        {
            User user = _userServices.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User id:" + id + " not found");
        }

        [HttpGet]
        [Route("api/[controller]/Login/{username}/{password}")]
        public IActionResult LogIn(string username,string password)
        {
            User user = _userServices.LogIn(username,password);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddUser(User user)
        {
            _userServices.AddUser(user);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + "/" + user.Id, user);
        }
    }
}
