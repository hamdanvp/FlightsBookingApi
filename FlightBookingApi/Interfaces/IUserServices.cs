using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.Interfaces
{
    public interface IUserServices
    {
        User AddUser(User user);
        List<User> GetAllUser();
        User GetUserById(Guid id);
        User LogIn(string userName, string password);
    }
}
