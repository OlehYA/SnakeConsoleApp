using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsoleApp.UserServices
{
    public static class Userinitializer
    {
        public static List<User> GetSampleUserDate()
        {

            List<User> users = new List<User>();

            users.Add(new User { Name = "Some  Name", Sroce = 123 });
            users.Add(new User { Name = "Some  Name2", Sroce = 124 });
            users.Add(new User { Name = "Simple user", Sroce = 3 });
            users.Add(new User { Name = "Professional User", Sroce = 500 });

            return users;
        }
    }

}
