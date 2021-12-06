using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet]
        public IActionResult ContactUs() => View();

        [HttpPost]
        public async Task<IActionResult> ContactUs(string name, string email, string subject, string message)
        {
            var emailService = new EmailService();
            var msg = $"Email from Reviefy user. Name: {name}. Email: {email}. Message:\n{message}";
            var sbj = $"Reviefy Question: {subject}";
            await emailService.SendEmailAsync("focus_test@mail.ru", sbj, msg);
            return Ok("Email successfully was send");
        }

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