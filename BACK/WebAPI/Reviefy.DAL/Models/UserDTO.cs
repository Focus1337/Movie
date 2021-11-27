using System;
using LinqToDB.Mapping;

// Data Transfer Objects
namespace Reviefy.DAL.Models
{
    // user_id INT NOT NULL IDENTITY,
    // password NVARCHAR(max) NOT NULL,
    // email NVARCHAR(max) NOT NULL,
    // first_name NVARCHAR(max) NOT NULL,
    // second_name NVARCHAR(max) NOT NULL,
    // register_date DATE NOT NULL,
    // avatar_url NVARCHAR(max), -- url to avatar img 
    // CONSTRAINT pk_user PRIMARY KEY(user_id)

    [Table(Name = "Users")]
    public class UserDTO
    {
        [Column("user_id", IsPrimaryKey = true), NotNull]
        public int UserId { get; set; }

        [Column("password"), NotNull]
        public string Password { get; set; }
        
        [Column("email"), NotNull]
        public string Email { get; set; }
        
        [Column("first_name"), NotNull] 
        public string FirstName { get; set; }
        
        [Column("second_name"), NotNull] 
        public string SecondName { get; set; }
        
        [Column("register_date"), NotNull] 
        public DateTime RegisterDate { get; set; }
        
        [Column("avatar_url"), NotNull]
        public string AvatarUrl { get; set; }
    }
}