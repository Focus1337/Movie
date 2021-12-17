using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reviefy.DataConnection;
using Reviefy.Models;
using Reviefy.Services;

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


        [HttpPost]
        public async Task<IActionResult> Contact(string name, string email, string subject, string message)
        {
            var emailService = new EmailService();
            var msg = $"Email from Reviefy user. Name: {name}. Email: {email}. Message:\n{message}";
            var sbj = $"Reviefy Question: {subject}";
            await emailService.SendEmailAsync("focus_test@mail.ru", sbj, msg);
            return Ok("Email successfully was send");
        }

        [HttpPost]
        public IActionResult Search(string title)
        {
            if (title == null)
                return RedirectToAction("PageNotFound", "Home");

            var minDistance = int.MaxValue;
            var matchingTitle = title;
            var titleToCompare = string.Concat(title.ToLower().Where(c => !char.IsWhiteSpace(c)));
            foreach (var movie in _connection.Movie.ToList())
            {
                var distance = LevenshteinDistance(titleToCompare,
                    string.Concat(movie.Title.ToLower().Where(c => !char.IsWhiteSpace(c))));

                if (distance == 0)
                    return RedirectToAction("GetMovie", "Movie", new {id = movie.MovieId});

                if (distance < minDistance)
                {
                    minDistance = distance;
                    matchingTitle = movie.Title;
                }
            }

            if (minDistance > 3)
                return RedirectToAction("PageNotFound", "Home");

            var matchingMovie = _connection.Movie.FirstOrDefault(x => x.Title == matchingTitle);

            return RedirectToAction("GetMovie", "Movie", new {id = matchingMovie?.MovieId});
        }

        private static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null)
                throw new ArgumentNullException(nameof(string1));
            if (string2 == null)
                throw new ArgumentNullException(nameof(string2));

            var m = new int[string1.Length + 1, string2.Length + 1];

            for (var i = 0; i <= string1.Length; i++)
                m[i, 0] = i;
            for (var j = 0; j <= string2.Length; j++)
                m[0, j] = j;

            for (var i = 1; i <= string1.Length; i++)
            for (var j = 1; j <= string2.Length; j++)
            {
                var diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
            }

            return m[string1.Length, string2.Length];
        }

        public IActionResult UserUnauthorized() => View();
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