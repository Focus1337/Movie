using System;

namespace Reviefy.BAL.Entities
{
    public class Users
    {
        public int UserId { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime RegisterDate { get; set; }

        public string AvatarUrl { get; set; }
    }
}