using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;


namespace Reviefy.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDataConnection _connection;
        public MovieController(AppDataConnection connection) => _connection = connection;

        private List<Movie> GetMoviesList() =>
            _connection.Movie.OrderByDescending(x => x.ReleaseDate).ToList();

        private List<User> GetUsersList() =>
            _connection.User.ToList();
        
        public IActionResult LatestMovies() => View(GetMoviesList());
        public IActionResult TopRatedMovies() => View();

        // GET
        public IActionResult GetMovie(Guid id)
        {
            if (_connection.Movie.All(x => x.MovieId != id))
                return RedirectToAction("PageNotFound", "Home");

            var viewModel = new ViewModel
            {
                Reviews = _connection.Review
                    .Where(x => x.MovieId == id)
                    .OrderBy(x => x.ReviewDate).ToList(),
                Users = GetUsersList(),

                MovieById = _connection.Movie.FirstOrDefault(x => x.MovieId == id),
                MoviePhotoById = _connection.MoviePhoto.FirstOrDefault(x => x.MovieId == id)
            };

            return View("MovieDetail", viewModel);
        }

        [HttpPost]
        public IActionResult WriteReview(int rating, string text, Guid movieId, Guid userId)
        {
            // TODO:Парсить id пользователя из хедера мб, хз как это сделать (пользователь должен быть залогинен по идее)
            var us = Guid.Parse("F9E234D4-F225-4AB9-99D8-84B81CA0257A");

            // Check if review is already exists
            var review = ReviewExists(movieId, us);
            if (review != null)
                return Ok("Your review already exists for this movie!");

            review = new Review
            {
                ReviewId = Guid.NewGuid(),
                MovieId = movieId,
                UserId = us,
                Helpfulness = 0,
                Rating = rating,
                Text = text,
                ReviewDate = DateTime.Now
            };

            _connection.Insert(review);

            return RedirectToAction("GetMovie", "Movie", new {id = movieId});
        }

        private Review ReviewExists(Guid movieId, Guid userId) =>
            _connection.Review.FirstOrDefault(u => u.MovieId == movieId && u.UserId == userId);
    }
}