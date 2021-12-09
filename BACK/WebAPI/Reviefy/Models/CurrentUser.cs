using System;

namespace Reviefy.Models
{
    public static class CurrentUser
    {
        public static Guid UserId { get; set; }

        public static string Password { get; set; }
        
        public static string Email { get; set; }
        
        public static string Nickname { get; set; }

        public static DateTime RegisterDate { get; set; }
        
        public static string AvatarPath { get; set; }

        public static bool IsLoggedIn { get; set; }

        public static string Token { get; set; }
    }
}