﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsoleApp.UserServices
{
    public class UserService
    {
        List<User> _users;

        public UserService()
        {
            _users = Userinitializer.GetSampleUserDate();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users.OrderByDescending(x => x.Sroce);
        }

        public User CreateUser(string name)
        {
            User user = new User();

            var existtUser = _users.Select(x => x.Name);

            try
            {
                if (name == "")
                    throw new ArgumentException("Name is empty");

                if (existtUser.Contains(name))
                    throw new ArgumentException("The user exists");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            user.Name = name;

            _users.Add(user);

            return user;
        }

        public void SaveScore(User user)
        {
            if (user.Name == null)
                return;

            _users.Add(user);
        }
    }
}
