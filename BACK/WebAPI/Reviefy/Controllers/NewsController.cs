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
    public class NewsController : Controller
    {
        private readonly AppDataConnection _connection;

        public NewsController(AppDataConnection connection) => _connection = connection;

        // GET
        public IActionResult LatestNews(Guid id)
        {
            if (id == Guid.Empty)
                return View(GetNews());

            var news = _connection.News.FirstOrDefault(account => account.NewsId == id);
            return news == null ? RedirectToAction("PageNotFound", "Home") : View("NewsDetail",news);
        }
        
        
        private List<News> GetNews() => _connection.News.OrderByDescending(x => x.NewsDate).ToList();
    }
}