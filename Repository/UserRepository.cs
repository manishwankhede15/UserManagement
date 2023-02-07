using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_User_Management.Model;

namespace WPF_User_Management.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly HashSet<User> userContext;

        public UserRepository()
        {
            this.userContext = new HashSet<User>();
            userContext.Add(new Model.User
            {
                Id=1,
                FirstName = "Manish",
                LastName = "Wankhede",
                Address = "At Post Surgaon",
                PhoneNumber = "88585",
                Email = "manish.wankhede",
                City = "Wardha",
                State = "Maharashtra",
                ZipCode = "85858",
                DateofBirth = new DateTime(1987, 06, 05)
            });
        }

        public  IEnumerable<User> GetUsers()
        {
            return  userContext.AsEnumerable<User>();
        }

        public IEnumerable<User> SearchUser(string text)
        {
            return  userContext.Where(a=>a.ToString().Contains(text)).ToHashSet();
        }
        public User? GetUser(int userId)
        {
            return  userContext.FirstOrDefault(e => e.Id == userId);
        }
        public bool AddUser(User user)
        {
            return userContext.Add(user);
        }

        public  User UpdateUser(User user)
        {
            var result =  userContext
                .FirstOrDefault(e => e.Id == user.Id);

            if (result != null)
            {
                
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Email = user.Email;
                result.DateofBirth = user.DateofBirth;
                result.Address = user.Address;
                result.PhoneNumber = user.PhoneNumber;
                result.ZipCode = user.ZipCode;
                result.City = user.City;
                result.State = user.State;

                return result;
            }

            return null;
        }

        public  void DeleteUser(int userId)
        {
            var result =  userContext
                .FirstOrDefault(e => e.Id == userId);
            if (result != null)
            {
                userContext.Remove(result);
            }
        }
    }
}
