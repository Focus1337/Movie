using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDataConnection _connection;

        public HomeController(AppDataConnection connection) => _connection = connection;

        private List<News> GetNews() =>
            _connection.News.OrderByDescending(x => x.NewsDate).Take(3).ToList();
        
        private List<Movie> GetMovies() =>
            _connection.Movie.OrderByDescending(x => x.ReleaseDate).Take(6).ToList();

        public IActionResult Index()
        {
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

        public IActionResult ContactUs() => View();

        public IActionResult AboutUs() => View();

        public IActionResult LegalDisclaimer() => View();

        public IActionResult PageNotFound() => View();

        public IActionResult PrivacyCookies() => View();

        public IActionResult TermsConditions() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}