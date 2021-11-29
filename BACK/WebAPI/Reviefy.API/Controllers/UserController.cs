using System;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.API.Entities;


namespace Reviefy.API.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDataConnection _connection;

        public UserController(AppDataConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public Task<Account[]> ListUser()
        {
            return _connection.User.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public Task<Account?> GetAccount(int id)
        {
            return _connection.User.SingleOrDefaultAsync(account => account.UserId == id);
        }

        [HttpDelete("{id}")]
        public Task<int> DeleteAccount(int id)
        {
            return _connection.User.Where(account => account.UserId == id).DeleteAsync();
        }

        [HttpPatch]
        public Task<int> UpdateAccount(Account account)
        {
            return _connection.UpdateAsync(account);
        }

        [HttpPatch("{id}/new-name")]
        public Task<int> UpdateAccountFirstName(int id, string newName)
        {
            return _connection.User.Where(account => account.UserId == id)
                .Set(account => account.FirstName, newName)
                .UpdateAsync();
        }

        [HttpPut]
        public Task<int> InsertAccount(Account account)
        {
            return _connection.InsertAsync(account);
        }
    }
}