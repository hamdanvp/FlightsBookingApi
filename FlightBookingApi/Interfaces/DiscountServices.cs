using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.Interfaces
{
    public class DiscountServices : IDiscountServices
    {
        FlightBookingDbContext _context;
        public DiscountServices(FlightBookingDbContext context)
        {
            _context = context;
        }
        public DiscountCoupon AddDiscount(DiscountCoupon coupon)
        {
            coupon.Id = Guid.NewGuid();
            _context.DiscountCoupons.Add(coupon);
            _context.SaveChanges();
            return coupon;
        }

        public DiscountCoupon GetCouponByCode(string couponCode)
        {
            return _context.DiscountCoupons.Where(x=>x.CouponCode==couponCode).FirstOrDefault();
        }

        public DiscountCoupon GetCouponById(Guid couponId)
        {
            return _context.DiscountCoupons.Where(x => x.Id == couponId).FirstOrDefault();
        }

        public List<DiscountCoupon> GetCoupons(SearchModel search)
        {
            List<DiscountCoupon> result = new List<DiscountCoupon>();
            if(search.StartDate!=null)
            {
                DateTime startDate = search.StartDate ?? DateTime.Now;
                result = _context.DiscountCoupons.Where(x => x.StartDate.Date <= startDate.Date && x.EndDate.Date >= startDate).ToList();
            }
            else
            {
                result = _context.DiscountCoupons.ToList();
            }
            return result;
        }
    }
}
