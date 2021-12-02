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
        public ITable<Movie> Movie => GetTable<Movie>();
        public ITable<News> News => GetTable<News>();
        public ITable<Review> Review => GetTable<Review>();
        public ITable<MoviePhoto> MoviePhoto => GetTable<MoviePhoto>();
        

        public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
            : base(options)
        {

        }
    }
}