using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDataConnection _connection;
        private List<Movie> GetMovies() =>
            _connection.Movie.OrderByDescending(x => x.ReleaseDate).ToList();
        public MovieController(AppDataConnection connection) => _connection = connection;

        // GET
        public IActionResult LatestMovies(Guid id)
        {
            if (id == Guid.Empty)
                return View(GetMovies());
            
            var movie = _connection.Movie.FirstOrDefault(account => account.MovieId == id);
            var moviePhoto = _connection.MoviePhoto.FirstOrDefault(account => account.MovieId == id);
            
            var viewModelObject = new ViewModelObject
            {
                Movie = movie,
                MoviePhoto = moviePhoto
            };

            //return movie == null ? RedirectToAction("PageNotFound", "Home") : View("MovieDetail",movie);
            return movie == null ? RedirectToAction("PageNotFound", "Home") : View("MovieDetail",viewModelObject);
        }
        
        
        public IActionResult TopRatedMovies() => View();
    }
}