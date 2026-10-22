using BagrutProject_2027.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static ObservableCollection<Game> Games { get; }
           = CreateGames();// this list is used to store the games and their corresponding information

        private static ObservableCollection<Game> CreateGames()// this method is used to create the list of games and their corresponding information
        {
            // Define each platform and its icon once.
            var gamePlatformDict =
                new Dictionary<string, GameConsole>
                {
                    {
                        "nintendo_switch",
                        new GameConsole
                        {
                            GameConsoleName = "Nintendo Switch",
                            GameConsoleIcon = "nintendo_switch.png"
                        }
                    },
                    {
                        "playstation_4",
                        new GameConsole
                        {
                            GameConsoleName = "PlayStation 4",
                            GameConsoleIcon = "playstation_4.png"
                        }
                    },
                    {
                        "xbox_one",
                        new GameConsole
                        {
                            GameConsoleName = "Xbox One",
                            GameConsoleIcon = "xbox_one.png"
                        }
                    },
                    {
                        "pc",
                        new GameConsole
                        {
                            GameConsoleName = "PC",
                            GameConsoleIcon = "pc.png"
                        }
                    },
                    {
                        "mobile",
                        new GameConsole
                        {
                            GameConsoleName = "Mobile",
                            GameConsoleIcon = "mobile.png"
                        }
                    }
                };

            // The five game definitions.
            return new ObservableCollection<Game>
            {
                new Game
                {
                    GameId = 1,
                    Title = "The Legend of Zelda: Breath of the Wild",
                    genre = "Action-adventure",
                    GameConsoles = new List<GameConsole>
                    {
                        gamePlatformDict["nintendo_switch"]
                    },
                    releaseDate = "March 3, 2017",
                    CoverImageURL =
                        "the_legend_of_zelda_breath_of_the_wild.jpg"
                },

                new Game
                {
                    GameId = 2,
                    Title = "Super Mario Odyssey",
                    genre = "Platform",
                    GameConsoles = new List<GameConsole>
                    {
                        gamePlatformDict["nintendo_switch"]
                    },
                    releaseDate = "October 27, 2017",
                    CoverImageURL = "super_mario_odyssey.jpg"
                },

                new Game
                {
                    GameId = 3,
                    Title = "Red Dead Redemption 2",
                    genre = "Action-adventure",
                    GameConsoles = new List<GameConsole>
                    {
                        gamePlatformDict["playstation_4"],
                        gamePlatformDict["xbox_one"],
                        gamePlatformDict["pc"]
                    },
                    releaseDate = "October 26, 2018",
                    CoverImageURL = "red_dead_red_2.jpg"
                },

                new Game
                {
                    GameId = 4,
                    Title = "The Witcher 3: Wild Hunt",
                    genre = "Action role-playing",
                    GameConsoles = new List<GameConsole>
                    {
                        gamePlatformDict["playstation_4"],
                        gamePlatformDict["xbox_one"],
                        gamePlatformDict["pc"]
                    },
                    releaseDate = "May 19, 2015",
                    CoverImageURL = "witcher_3.jpg"
                },

                new Game
                {
                    GameId = 5,
                    Title = "Minecraft",
                    genre = "Sandbox, survival",
                    GameConsoles = new List<GameConsole>
                    {
                        gamePlatformDict["pc"],
                        gamePlatformDict["nintendo_switch"],
                        gamePlatformDict["mobile"]
                    },
                    releaseDate = "November 18, 2011",
                    CoverImageURL = "minecraft_cover.png"
                }
            };
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
