using System;
using System.Linq;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Helpers;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDataConnection _connection;
        public ReviewController(AppDataConnection connection) => _connection = connection;

        [HttpPost]
        public IActionResult WriteReview(int rating, string text, Guid movieId)
        {
            // TODO:Парсить id пользователя из хедера мб, хз как это сделать (пользователь должен быть залогинен по идее)
            
            // Check if review is already exists
            var review = ReviewExists(movieId, GetUserBySession().UserId);
            
            if (review != null)
                return Ok("Your review already exists for this movie!");

            review = new Review
            {
                ReviewId = Guid.NewGuid(),
                MovieId = movieId,
                UserId = GetUserBySession().UserId,
                Helpfulness = 0,
                Rating = rating,
                Text = text,
                ReviewDate = DateTime.Now
            };

            _connection.Insert(review);

            return RedirectToAction("GetMovie", "Movie", new {id = movieId});
        }

        public IActionResult IncreaseHelpfulness(Guid id)
        {
            if (!UserExistInSession())
                return Ok("You must be logged in!");

            var review = _connection.Review.FirstOrDefault(u => u.ReviewId == id);

            if (review != null)
            {
                review.Helpfulness++;
                _connection.Update(review);
            }

            return NoContent();
        }

        public IActionResult DecreaseHelpfulness(Guid id)
        {
            if (!UserExistInSession())
                return Ok("You must be logged in!");
            
            var review = _connection.Review.FirstOrDefault(u => u.ReviewId == id);

            if (review != null)
            {
                review.Helpfulness--;
                _connection.Update(review);
            }

            return NoContent();
        }

        private Review ReviewExists(Guid movieId, Guid userId) =>
            _connection.Review.FirstOrDefault(u => u.MovieId == movieId && u.UserId == userId);
        

        private bool UserExistInSession() => 
            HttpContext.Session.Keys.Contains("user");

        private User GetUserBySession() => 
            HttpContext.Session.Get<User>("user");
    }
}