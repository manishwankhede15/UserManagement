using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_User_Management.Model;

namespace WPF_User_Management.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> SearchUser(string text);
        User GetUser(int userId);
        bool AddUser(User user);
        User UpdateUser(User employee);
        void DeleteUser(int employeeId);
    }
}
