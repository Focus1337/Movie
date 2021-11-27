using System;
using LinqToDB;
using LinqToDB.Mapping;
using Reviefy.DAL.Models;

namespace Reviefy.DAL
{
    public class DBRepository : LinqToDB.Data.DataConnection
    {
        public DBRepository() : base("Reviefy")
        { }

        public ITable<UserDTO> Users => GetTable<UserDTO>();
    }
}