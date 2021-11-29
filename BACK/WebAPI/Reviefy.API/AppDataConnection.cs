using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Reviefy.API.Entities;

namespace Reviefy.API
{
    public class AppDataConnection : DataConnection
    {
        public ITable<Account> User => GetTable<Account>();
        public ITable<Person> People => GetTable<Person>();

        public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
            : base(options)
        {

        }
    }
}