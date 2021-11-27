using System;
using System.Linq;
using LinqToDB;
using Reviefy.DAL;
using Reviefy.DAL.Models;

namespace Reviefy.BAL
{
    public static class UserLogic
    {
        public static bool IsExist(UserDTO userDto)
        {
            using var db = new DBRepository();
            var query = from p in db.Users
                where p.Email == userDto.Email
                select p;

            return query.Any();
        }

        public static bool IsCorrectInfo(UserDTO userDto)
        {
            using var db = new DBRepository();
            var query = from p in db.Users
                where p.Email == userDto.Email &&
                      p.Password == userDto.Password
                select p;

            return query.Any();
        }

        public static void Create(UserDTO userDto)
        {
            using var db = new DBRepository();
            db.Insert(userDto);
        }
    }
}