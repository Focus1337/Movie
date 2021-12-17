using System;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;
using Reviefy.Repository;

namespace Reviefy.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDataConnection _connection;
        public MovieController(AppDataConnection connection) => _connection = connection;

        public IActionResult LatestMovies() => View(DbHelper.MoviesListOrdered(_connection));
        public IActionResult TopRatedMovies() => View();

        public IActionResult GetMovie(Guid id)
        {
            if (DbHelper.MovieById(id, _connection) == null)
                return RedirectToAction("PageNotFound", "Home");

            var viewModel = new ViewModel
            {
                Reviews = DbHelper.ReviewListById(id, _connection),
                Users = DbHelper.UsersList(_connection),

                MovieById = DbHelper.MovieById(id, _connection),
                MoviePhotoById = DbHelper.MoviePhotoById(id, _connection)
            };

            return View("MovieDetail", viewModel);
        }
    }
}