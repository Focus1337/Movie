using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reviefy.DataConnection;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDataConnection _connection;
        public MovieController(AppDataConnection connection) => _connection = connection;

        private Movie GetMovieById(Guid id) =>
            _connection.Movie.FirstOrDefault(m => m.MovieId == id);

        private List<Movie> GetMoviesList() =>
            _connection.Movie.OrderByDescending(m => m.ReleaseDate).ToList();

        private MoviePhoto GetMoviePhotoById(Guid id) =>
            _connection.MoviePhoto.FirstOrDefault(m => m.MovieId == id);

        private List<User> GetUsersList() =>
            _connection.User.ToList();

        private List<Review> GetReviewListById(Guid id) =>
            _connection.Review
                .Where(m => m.MovieId == id)
                .OrderBy(r => r.ReviewDate).ToList();

        public IActionResult LatestMovies() => View(GetMoviesList());
        public IActionResult TopRatedMovies() => View();

        public IActionResult GetMovie(Guid id)
        {
            if (GetMovieById(id) == null)
                return RedirectToAction("PageNotFound", "Home");

            var viewModel = new ViewModel
            {
                Reviews = GetReviewListById(id),
                Users = GetUsersList(),

                MovieById = GetMovieById(id),
                MoviePhotoById = GetMoviePhotoById(id)
            };

            return View("MovieDetail", viewModel);
        }
    }
}