using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Reviefy.Models;

namespace Reviefy
{
    // Custom Data Connection
    public class AppDataConnection : DataConnection
    {
        public ITable<User> User => GetTable<User>();
        public ITable<Person> Person => GetTable<Person>();
        public ITable<Movie> Movie => GetTable<Movie>();
        public ITable<News> News => GetTable<News>();

        public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
            : base(options)
        {

        }
    }
}