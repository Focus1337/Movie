using System;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDataConnection _connection;

        public PersonController(AppDataConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public Task<Person[]> ListPerson()
        {
            return _connection.Person.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public Task<Person?> GetPerson(Guid id)
        {
            return _connection.Person.SingleOrDefaultAsync(person => person.Id == id);
        }

        [HttpDelete("{id}")]
        public Task<int> DeletePerson(Guid id)
        {
            return _connection.Person.Where(person => person.Id == id).DeleteAsync();
        }

        [HttpPatch]
        public Task<int> UpdatePerson(Person person)
        {
            return _connection.UpdateAsync(person);
        }

        [HttpPatch("{id}/new-name")]
        public Task<int> UpdatePersonName(Guid id, string newName)
        {
            return _connection.Person.Where(person => person.Id == id)
                .Set(person => person.Name, newName)
                .UpdateAsync();
        }

        [HttpPut]
        public Task<int> InsertPerson(Person person)
        {
            return _connection.InsertAsync(person);
        }
    }
}