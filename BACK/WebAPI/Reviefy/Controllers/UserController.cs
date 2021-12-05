using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDataConnection _connection;
        public UserController(AppDataConnection connection) => _connection = connection;
        
        private List<Movie> GetMoviesList() =>
            _connection.Movie.OrderByDescending(x => x.ReleaseDate).ToList();

        // GET
        public IActionResult UserProfile(Guid id)
        {
            if (_connection.User.All(x => x.UserId != id))
                return RedirectToAction("PageNotFound", "Home");
            
            var viewModel = new ViewModel
            {
                Movies = GetMoviesList(),
                Reviews = _connection.Review
                    .Where(x => x.UserId == id)
                    .OrderByDescending(x => x.ReviewDate).ToList(),

                UserById = _connection.User.FirstOrDefault(x => x.UserId == id)
            };

            return View("UserProfile", viewModel);
        }

        public IActionResult MyProfile() => View();
    }
}