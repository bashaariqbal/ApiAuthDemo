using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiDemoWithAuth.Models;

namespace ApiDemoWithAuth.Services
{
    public class UserService
    {
        private static List<User> Users = new List<User>();

        private void GetAllUsers()
        {

            if (Users.Count < 1)
            {
                Users = new List<User>();
                Users.Add(new User { Id = 1, Password = "admin", UserName = "admin", Role = "admin" });
                Users.Add(new User { Id = 2, Password = "user", UserName = "user", Role = "user" });
            }
        }
        public UserService()
        {
            GetAllUsers();

        }

        public User GetUserByUsernameAndPassword( string userName, string password)
        {
            return Users.Find(u => u.UserName == userName && u.Password == password);
        }



    }
}