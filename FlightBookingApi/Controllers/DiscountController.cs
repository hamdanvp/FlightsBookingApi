using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Interfaces;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.Controllers
{
    
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IDiscountServices _services;
        public DiscountController(IDiscountServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetCoupons([FromQuery] SearchModel search)
        {
            return Ok(_services.GetCoupons(search));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetCouponById(Guid id)
        {
            DiscountCoupon discountCoupon = _services.GetCouponById(id);
            if (discountCoupon != null)
            {
                return Ok(discountCoupon);
            }
            return NotFound("Discount id:" + id + " not found");
        }

        [HttpGet]
        [Route("api/[controller]/GetCouponByCode/{couponCode}")]
        public IActionResult GetCouponByCode(string couponCode)
        {
            DiscountCoupon discountCoupon = _services.GetCouponByCode(couponCode);
            if (discountCoupon != null)
            {
                return Ok(discountCoupon);
            }
            return NotFound("Discount code:" + couponCode + " not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddDiscount(DiscountCoupon discountCoupon)
        {
            _services.AddDiscount(discountCoupon);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + "/" + discountCoupon.Id, discountCoupon);
        }


    }
}
