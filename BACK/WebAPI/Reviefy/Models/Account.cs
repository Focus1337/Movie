using System;
using LinqToDB.Mapping;

namespace Reviefy.Models
{
    [Table(Name = "Users")]
    public class Account
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