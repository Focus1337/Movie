using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Reviefy.Models;

namespace Reviefy
{
    public class AppDataConnection : DataConnection
    {
        public ITable<Account> Account => GetTable<Account>();
        public ITable<Person> Person => GetTable<Person>();

        public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
            : base(options)
        {

        }
    }
}