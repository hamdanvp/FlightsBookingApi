using FlightBookingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Interfaces
{
    public class UserServices : IUserServices
    {
        private FlightBookingDbContext _context;
        public UserServices(FlightBookingDbContext context)
        {
            _context = context;
        }
        public User AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User LogIn(string userName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}
