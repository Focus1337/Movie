using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Attributes;
using Reviefy.DataConnection;
using Reviefy.Models;
using Reviefy.Security;
using Reviefy.Services;

namespace Reviefy.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDataConnection _connection;
        public UserController(AppDataConnection connection) => _connection = connection;

        private List<Movie> GetMovies() =>
            _connection.Movie.OrderByDescending(m => m.ReleaseDate).ToList();

        private List<Review> GetReviewListById(Guid id) =>
            _connection.Review
                .Where(u => u.UserId == id)
                .OrderByDescending(r => r.ReviewDate).ToList();

        private User GetUserById(Guid id) =>
            _connection.User.FirstOrDefault(u => u.UserId == id);
        
        
        
        private Guid UserIdFromJwt()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("Authorization"))
                return Guid.Empty;
            
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(HttpContext.Request.Cookies["Authorization"]); //(token);
            return Guid.Parse(jwtSecurityToken.Claims.First(claim => claim.Type == "id").Value);
        }

        private bool IsCurrentUserExists() =>
            _connection.User.Contains(_connection.User.FirstOrDefault(x => x.UserId == UserIdFromJwt()));
        
        private User GetCurrentUser() =>
            _connection.User.FirstOrDefault(x => x.UserId == UserIdFromJwt());
        
        

        private RedirectToActionResult RedirectToPageNotFound() =>
            RedirectToAction("PageNotFound", "Home");

        public IActionResult UserProfile(Guid id)
        {
            if (GetUserById(id) == null)
                return RedirectToPageNotFound();

            var viewModel = new ViewModel
            {
                Movies = GetMovies(),
                Reviews = GetReviewListById(id),
                UserById = GetUserById(id)
            };

            return View("UserProfile", viewModel);
        }

        [Authorize, HttpPost]
        public IActionResult ResetAvatar()
        {
            var user = GetUserById(GetCurrentUser().UserId);
            if (!IsCurrentUserExists())
                return RedirectToPageNotFound();

            user.AvatarPath = "https://i.imgur.com/dNOjQWC.png";
            _connection.Update(user);

            return NoContent();
        }

        [Authorize, HttpPost]
        public IActionResult UpdateInformation(string nickname, string avatar)
        {
            var user = GetUserById(GetCurrentUser().UserId);
            if (!IsCurrentUserExists())
                return RedirectToPageNotFound();

            if (user.Nickname != nickname)
                user.Nickname = nickname;

            if (user.AvatarPath != avatar)
                user.AvatarPath = avatar;

            _connection.Update(user);

            return NoContent();
        }

        [Authorize, HttpPost]
        public IActionResult UpdateSecurity(string email, string password)
        {
            var user = GetUserById(GetCurrentUser().UserId);
            if (!IsCurrentUserExists())
                return RedirectToPageNotFound();

            if (user.Email != email)
                user.Email = email;

            if (user.Password != password)
                user.Password = PassHashing.Encrypt(password);

            _connection.Update(user);

            return NoContent();
        }

        [Authorize]
        public IActionResult MyProfile()
        {
            if (!IsCurrentUserExists())
                return RedirectToPageNotFound();

            var viewModel = new ViewModel
            {
                Movies = GetMovies(),
                Reviews = GetReviewListById(GetCurrentUser().UserId),
                UserById = GetUserById(GetCurrentUser().UserId)
            };

            return View(viewModel);
        }
    }
}