using System;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;
using Reviefy.Repository;

namespace Reviefy.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDataConnection _connection;
        public NewsController(AppDataConnection connection) => _connection = connection;
        
        public IActionResult LatestNews() => View(DbHelper.NewsListOrdered(_connection));

        public IActionResult GetNews(Guid id)
        {
            if (DbHelper.NewsById(id, _connection) == null)
                return RedirectToAction("PageNotFound", "Home");

            var viewModel = new ViewModel
            {
                NewsById = DbHelper.NewsById(id, _connection)
            };

            return View("NewsDetail", viewModel);
        }
    }
}