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

   // [Route("Movie")]
    public class MovieController : Controller
    {
        private readonly AppDataConnection _connection;
        private List<Movie> GetMovies() =>
            _connection.Movie.OrderByDescending(x => x.ReleaseDate).ToList();
        
        public MovieController(AppDataConnection connection) => _connection = connection;

        // GET
        // [Route("")]
        // [Route("Index")]
        // [Route("Index/{id?}")]
        public IActionResult LatestMovies(Guid id)
        {
            if (id == Guid.Empty)
                return View(GetMovies());

            var movie = _connection.Movie.FirstOrDefault(account => account.MovieId == id);
            return movie == null ? RedirectToAction("PageNotFound", "Home") : View("MovieDetail",movie);
        }
        
        
        public IActionResult TopRatedMovies()
        {
            return View();
        }
    }
}