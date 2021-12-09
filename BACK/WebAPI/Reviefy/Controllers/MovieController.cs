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
    }
}