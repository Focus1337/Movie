using System;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Attributes;
using Reviefy.Models;
using Reviefy.Repository;

namespace Reviefy.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDataConnection _connection;
        public ReviewController(AppDataConnection connection) => _connection = connection;

        private User CurrentUser() => (User) HttpContext.Items["User"]!;

        [Authorize, HttpPost]
        public IActionResult WriteReview(int rating, string text, Guid movieId)
        {
            if (!DbHelper.IsUserExists(CurrentUser().UserId, _connection))
                return Ok("You must be logged in!");
            
            // Check if review is already exists
            var review = DbHelper.ReviewExists(movieId, CurrentUser().UserId, _connection);

            if (review != null)
                return Ok("Your review already exists for this movie!");

            review = new Review
            {
                ReviewId = Guid.NewGuid(),
                MovieId = movieId,
                UserId = CurrentUser().UserId,
                Helpfulness = 0,
                Rating = rating,
                Text = text,
                ReviewDate = DateTime.Now
            };
            
            _connection.Insert(review);

            return RedirectToAction("GetMovie", "Movie", new {id = movieId});
        }
       
        [Authorize]
        public IActionResult IncreaseHelpfulness(Guid id)
        {
            if (!DbHelper.IsUserExists(CurrentUser().UserId, _connection))
                return Ok("You must be logged in!");

            var review = DbHelper.ReviewById(id, _connection);

            if (review != null)
            {
                review.Helpfulness++;
                _connection.Update(review);
            }

            return NoContent();
        }

        [Authorize]
        public IActionResult DecreaseHelpfulness(Guid id)
        {
            if (!DbHelper.IsUserExists(CurrentUser().UserId, _connection))
                return Ok("You must be logged in!");

            var review = DbHelper.ReviewById(id, _connection);

            if (review != null)
            {
                review.Helpfulness--;
                _connection.Update(review);
            }

            return NoContent();
        }
    }
}