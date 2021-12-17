using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;
using Reviefy.Repository;
using Reviefy.Services;

namespace Reviefy.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDataConnection _connection;

        public HomeController(AppDataConnection connection) => _connection = connection;
        
        public IActionResult Index()
        {
            var viewModel = new ViewModel
            {
                Movies = DbHelper.MoviesListByCount(6, _connection),
                News = DbHelper.NewsListByCount(3, _connection)
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

            return NoContent();
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
                var distance = MovieSearcher.LevenshteinDistance(titleToCompare,
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