using BagrutProject_2027.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagrutProject_2027.Services
{
    internal static class DataRepo// this class is used to store the users and their corresponding information
    {
        public static List<User> Users = new List<User>()
        {
            new User { UserId = 1, Name = "admin", Email = "admin@gmail.com",
                       Password = "123456", PName = "Admin", FName = "Test",
                       BirthDate = new DateTime(1990, 1, 1) }
        };

        public static List<User> Users1 = new List<User>()
        {
            new User { UserId = 2, Name = "alex", Email = "alex@gmail.com",
                       Password = "123456", PName = "Alex", FName = "void",
                       BirthDate = new DateTime(2009, 1, 27) }
        };
        public static List<User> Users2 = new List<User>()
        {
            new User { UserId = 3, Name = "yonatan", Email = "yonatan@gmail.com",
                       Password = "123456", PName = "Yonatan", FName = "potato",
                       BirthDate = new DateTime(2009, 1, 3) }
        };
        public static List<User> Users3 = new List<User>()
        {
            new User { UserId = 4, Name = "yair", Email = "yair@gmail.com",
                       Password = "123456", PName = "Yair", FName = "guata",
                       BirthDate = new DateTime(2009 , 10, 4) }
        };

        // returns the user if email+password match, otherwise null
        public static User? Login(string email, string password)// checks if the email and password match a user in the list
        {
            foreach (User u in Users)
            {
                if (u.Email == email && u.Password == password)
                    return u;
            }
            return null;
        }

        // true if this email is already registered
        public static bool EmailExists(string email)// checks if the email is already registered
        {
            foreach (User u in Users)
            {
                if (u.Email == email)
                    return true;
            }
            return false;
        }

        public static void Add(User user)// adds a new user to the list of users
        {
            user.UserId = Users.Count + 1;
            Users.Add(user);
        }
    }
}
