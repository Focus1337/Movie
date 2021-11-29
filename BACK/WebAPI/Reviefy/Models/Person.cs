using System;
using LinqToDB.Mapping;

namespace Reviefy.Models
{
    public class Person
    {
        [PrimaryKey] public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}