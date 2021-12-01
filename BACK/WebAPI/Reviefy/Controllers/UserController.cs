using System;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDataConnection _connection;

        public UserController(AppDataConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public Task<User[]> ListUser()
        {
            return _connection.User.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public Task<User?> GetUser(Guid id)
        {
            return _connection.User.SingleOrDefaultAsync(account => account.UserId == id);
        }

        [HttpDelete("{id}")]
        public Task<int> DeleteUser(Guid id)
        {
            return _connection.User.Where(account => account.UserId == id).DeleteAsync();
        }

        [HttpPut]
        public Task<int> InsertUser(User user)
        {
            return _connection.InsertAsync(user);
        }
    }
}