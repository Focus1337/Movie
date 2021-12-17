using System;
using System.Collections.Generic;
using System.Linq;
using Reviefy.Models;

namespace Reviefy.Repository
{
    public static class DbHelper
    {
        // Return List of entity
        public static List<User> UsersList(AppDataConnection connection) =>
            connection.User.ToList();

        public static List<Movie> MoviesList(AppDataConnection connection) =>
            connection.Movie.ToList();

        public static List<Movie> MoviesListOrdered(AppDataConnection connection) =>
            connection.Movie.OrderByDescending(m => m.ReleaseDate).ToList();

        public static List<News> NewsListOrdered(AppDataConnection connection) =>
            connection.News.OrderByDescending(x => x.NewsDate).ToList();

        public static List<Review> ReviewListById(Guid id, AppDataConnection connection) =>
            connection.Review
                .Where(m => m.MovieId == id)
                .OrderBy(r => r.ReviewDate).ToList();

        public static List<Review> ReviewListDescById(Guid id, AppDataConnection connection) =>
            connection.Review
                .Where(u => u.UserId == id)
                .OrderByDescending(r => r.ReviewDate).ToList();

        public static List<News> NewsListByCount(int count, AppDataConnection connection) =>
            connection.News.OrderByDescending(x => x.NewsDate).Take(count).ToList();

        public static List<Movie> MoviesListByCount(int count, AppDataConnection connection) =>
            connection.Movie.OrderByDescending(x => x.ReleaseDate).Take(count).ToList();


        // Return entity by id
        public static User UserById(Guid id, AppDataConnection connection) =>
            connection.User.FirstOrDefault(u => u.UserId == id);

        public static User UserByEmail(string email, AppDataConnection connection) =>
            connection.User.FirstOrDefault(u => u.Email == email);

        public static User AuthenticateUser(string email, string password, AppDataConnection connection) =>
            connection.User.FirstOrDefault(u => u.Email == email && u.Password == password);

        public static Movie MovieById(Guid id, AppDataConnection connection) =>
            connection.Movie.FirstOrDefault(m => m.MovieId == id);

        public static MoviePhoto MoviePhotoById(Guid id, AppDataConnection connection) =>
            connection.MoviePhoto.FirstOrDefault(m => m.MovieId == id);

        public static Review ReviewById(Guid id, AppDataConnection connection) =>
            connection.Review.FirstOrDefault(r => r.ReviewId == id);

        public static News NewsById(Guid id, AppDataConnection connection) =>
            connection.News.FirstOrDefault(n => n.NewsId == id);

        public static Review ReviewExists(Guid movieId, Guid userId, AppDataConnection connection) =>
            connection.Review.FirstOrDefault(r => r.MovieId == movieId && r.UserId == userId);
    }
}