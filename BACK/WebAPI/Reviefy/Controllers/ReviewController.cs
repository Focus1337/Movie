using System;
using System.Linq;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.DataConnection;
using Reviefy.Models;
using Reviefy.Services;

namespace Reviefy.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDataConnection _connection;
        public ReviewController(AppDataConnection connection) => _connection = connection;

        private Review ReviewExists(Guid movieId, Guid userId) =>
            _connection.Review.FirstOrDefault(r => r.MovieId == movieId && r.UserId == userId);

        private Review GetReviewById(Guid id) =>
            _connection.Review.FirstOrDefault(r => r.ReviewId == id);
        
        private bool IsCurrentUserExists() =>
            HttpContext.Session.Keys.Contains("user");

        private User GetCurrentUser() =>
            HttpContext.Session.Get<User>("user");


        [HttpPost]
        public IActionResult WriteReview(int rating, string text, Guid movieId)
        {
            if (!IsCurrentUserExists())
                return Ok("You must be logged in!");
            
            // Check if review is already exists
            var review = ReviewExists(movieId, GetCurrentUser().UserId);

            if (review != null)
                return Ok("Your review already exists for this movie!");

            review = new Review
            {
                ReviewId = Guid.NewGuid(),
                MovieId = movieId,
                UserId = GetCurrentUser().UserId,
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
            if (!IsCurrentUserExists())
                return Ok("You must be logged in!");

            var review = GetReviewById(id);

            if (review != null)
            {
                review.Helpfulness++;
                _connection.Update(review);
            }

            return NoContent();
        }

        public IActionResult DecreaseHelpfulness(Guid id)
        {
            if (!IsCurrentUserExists())
                return Ok("You must be logged in!");

            var review = GetReviewById(id);

            if (review != null)
            {
                review.Helpfulness--;
                _connection.Update(review);
            }

            return NoContent();
        }
    }
}