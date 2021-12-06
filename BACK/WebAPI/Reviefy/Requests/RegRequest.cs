using System.ComponentModel.DataAnnotations;

namespace Reviefy.Requests
{
    public class RegRequest
    {
        [Required]
        public string Nickname { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Incorrect email address!")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$",
            ErrorMessage =
                "Password length must be between 8 and 16. Must contain at least one number and upper and lower case characters!")]
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords differ!")]
        public string ConfirmPassword { get; set; }
    }
}