using System;
using System.Collections.Generic;
using System.Text;

namespace BagrutProject_2027.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string PName { get; set; } = "";   // first name
        public string FName { get; set; } = "";   // last name
        public DateTime BirthDate { get; set; }

    }
}
