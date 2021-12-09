using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reviefy.DataConnection;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDataConnection _connection;
        public NewsController(AppDataConnection connection) => _connection = connection;

        private List<News> GetNewsList() =>
            _connection.News.OrderByDescending(x => x.NewsDate).ToList();

        private News GetNewsById(Guid id) =>
            _connection.News.FirstOrDefault(n => n.NewsId == id);

        public IActionResult LatestNews() => View(GetNewsList());

        public IActionResult GetNews(Guid id)
        {
            if (GetNewsById(id) == null)
                return RedirectToAction("PageNotFound", "Home");

            var viewModel = new ViewModel
            {
                NewsById = GetNewsById(id)
            };

            return View("NewsDetail", viewModel);
        }
    }
}