using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDataConnection _connection;
        public NewsController(AppDataConnection connection) => _connection = connection;
        private List<News> GetNewsList() => 
            _connection.News.OrderByDescending(x => x.NewsDate).ToList();

        public IActionResult LatestNews() => View(GetNewsList());

        // GET
        public IActionResult GetNews(Guid id)
        {
            if (_connection.News.All(x => x.NewsId != id))
                return RedirectToAction("PageNotFound", "Home");

            var viewModel = new ViewModel
            {
                NewsById = _connection.News.FirstOrDefault(x => x.NewsId == id)
            };

            return View("NewsDetail", viewModel);
        }
    }
}