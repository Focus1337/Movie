using System;
using LinqToDB.Mapping;

namespace Reviefy.Models
{
    [Table(Name = "Users")]
    public class User
    {
        [Column("user_id"), PrimaryKey, NotNull]
        public Guid UserId { get; set; }// = Guid.NewGuid();

        [Column("password"), NotNull]
        public string Password { get; set; }
        
        [Column("email"), NotNull]
        public string Email { get; set; }
        
        [Column("nickname"), NotNull] 
        public string Nickname { get; set; }

        [Column("register_date"), NotNull] 
        public DateTime RegisterDate { get; set; }
        
        [Column("avatar_url"), NotNull]
        public string AvatarUrl { get; set; }
    }
}