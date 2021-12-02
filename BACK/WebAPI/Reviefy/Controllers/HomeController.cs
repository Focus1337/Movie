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
    public class HomeController : Controller
    {
        private readonly AppDataConnection _connection;
        
        public HomeController(AppDataConnection connection)
        {
            _connection = connection;
        }

        private IEnumerable<News> GetNews() =>
            _connection.News.OrderByDescending(x => x.NewsDate).ToList().Take(3);

        private IEnumerable<Movie> GetMovies() =>
            _connection.Movie.OrderByDescending(x => x.ReleaseDate).ToList().Take(6);

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to my demo!";
            var viewModel = new ViewModel
            {
                Movies = GetMovies(),
                News = GetNews()
            };
            return View("Index", viewModel);
        }

        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult Movies()
        {
            return View();
        }

        public IActionResult MovieDetail()
        {
            return View();
        }


        public IActionResult LegalDisclaimer()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult PrivacyCookies()
        {
            return View();
        }

        public IActionResult TermsConditions()
        {
            return View();
        }

        public IActionResult TopRatedMovies()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}