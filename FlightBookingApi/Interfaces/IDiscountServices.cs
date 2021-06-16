using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.Interfaces
{
    public interface IDiscountServices
    {
        DiscountCoupon AddDiscount(DiscountCoupon coupon);
        DiscountCoupon GetCouponById(Guid couponId);
        DiscountCoupon GetCouponByCode(string couponCode);
        List<DiscountCoupon> GetCoupons(SearchModel search);
    }
}
