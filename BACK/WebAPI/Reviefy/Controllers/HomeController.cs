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
        // private readonly ILogger<HomeController> _logger;
        //
        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }
        //
        public HomeController(AppDataConnection connection)
        {
            _connection = connection;
        }

        public IActionResult Index()
        {
            return View();
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
        
        //public IActionResult News() => View();
        
        //[HttpGet("{id}")]
        public IActionResult News(Guid id)
        {
            if (id != default)
            {
                return View("NewsDetail", _connection.News.FirstOrDefault(news => news.NewsId == id));
                // return context.ServiceItems.FirstOrDefault(x => x.Id == id);
            }
            
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        
            
            return View();
        }

        public string Test(int id)
        {
            var abob = DateTime.Now.ToString("d");
            
            return $"id= {id}";
           
            
            
            // return View();
        }
        
        
        // public string Pomogite(Guid id)
        // {
        //     return _connection.News.FirstOrDefault(account => account.NewsId == id)?.Title;
        // }
        
        public IActionResult Amogus(Guid id)
        {
            //return View(_connection.News.FirstOrDefault(account => account.NewsId == id));

            var news = _connection.News.FirstOrDefault(account => account.NewsId == id);
            if (news == null)
            {
                return View("PageNotFound");
            }

            return View(news);
        }
        
        public IActionResult Abobus(Guid id)
        {
            //return View(_connection.News.FirstOrDefault(account => account.NewsId == id));

            var news = _connection.News.FirstOrDefault(account => account.NewsId == id);
            if (news == null)
            {
                return View("PageNotFound");
            }

            return View(news);
        }
        
        //public IActionResult NewsDetail() => View();

        // public IActionResult LatestNews(Guid id)
        // {
        //     if (id != default)
        //         return View("NewsDetail");
        //     
        //     return View();
        // }

        // [HttpGet("{id}")]
        // public IActionResult Movies(Guid id)
        // {
        //     if (id != default)
        //     {
        //         return View("MovieDetail", _connection.Movie.SingleOrDefaultAsync(movie => movie.MovieId == id));
        //     }
        //
        //     return View();
        // }
        
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