// using System.Linq;
// using LinqToDB;
// using Reviefy.API.Entities;
//
// namespace Reviefy.API
// {
//     public static class UserLogic
//     {
//         public static bool IsExist(User userDto)
//         {
//             using var db = new DBRepository();
//             var query = from p in db.Users
//                 where p.Email == userDto.Email
//                 select p;
//
//             return query.Any();
//         }
//
//         public static bool IsCorrectInfo(User userDto)
//         {
//             using var db = new DBRepository();
//             var query = from p in db.Users
//                 where p.Email == userDto.Email &&
//                       p.Password == userDto.Password
//                 select p;
//
//             return query.Any();
//         }
//
//         public static void Create(User userDto)
//         {
//             using var db = new DBRepository();
//             db.Insert(userDto);
//         }
//     }
// }