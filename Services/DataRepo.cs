using BagrutProject_2027.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagrutProject_2027.Services
{
    internal static class DataRepo
    {
        public static List<User> Users = new List<User>()
        {
            new User { UserId = 1, Name = "admin", Email = "admin@test.com",
                       Password = "123456", PName = "Admin", FName = "Test",
                       BirthDate = new DateTime(1990, 1, 1) }
        };

        public static List<User> Users1 = new List<User>()
        {
            new User { UserId = 2, Name = "alex", Email = "alex@test.com",
                       Password = "123456", PName = "Alex", FName = "Test",
                       BirthDate = new DateTime(1990, 1, 1) }
        };
        public static List<User> Users2 = new List<User>()
        {
            new User { UserId = 3, Name = "yonatan", Email = "yonatan@test.com",
                       Password = "123456", PName = "Yonatan", FName = "Test",
                       BirthDate = new DateTime(1990, 1, 1) }
        };
        public static List<User> Users3 = new List<User>()
        {
            new User { UserId = 4, Name = "yair", Email = "yair@test.com",
                       Password = "123456", PName = "Yair", FName = "Test",
                       BirthDate = new DateTime(1990, 1, 1) }
        };

        // returns the user if email+password match, otherwise null
        public static User? Login(string email, string password)
        {
            foreach (User u in Users)
            {
                if (u.Email == email && u.Password == password)
                    return u;
            }
            return null;
        }

        // true if this email is already registered
        public static bool EmailExists(string email)
        {
            foreach (User u in Users)
            {
                if (u.Email == email)
                    return true;
            }
            return false;
        }

        public static void Add(User user)
        {
            user.UserId = Users.Count + 1;
            Users.Add(user);
        }
    }
}
