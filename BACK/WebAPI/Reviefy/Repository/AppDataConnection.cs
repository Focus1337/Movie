using LinqToDB;
using LinqToDB.Configuration;
using Reviefy.Models;

namespace Reviefy.Repository
{
    // Custom Data Connection
    public class AppDataConnection : LinqToDB.Data.DataConnection
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