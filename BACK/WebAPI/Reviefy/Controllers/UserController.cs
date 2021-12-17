using System;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Attributes;
using Reviefy.Models;
using Reviefy.Repository;
using Reviefy.Security;

namespace Reviefy.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDataConnection _connection;
        public UserController(AppDataConnection connection) => _connection = connection;

        private User CurrentUser() => (User) HttpContext.Items["User"]!;

        private RedirectToActionResult RedirectToPageNotFound() =>
            RedirectToAction("PageNotFound", "Home");

        public IActionResult UserProfile(Guid id)
        {
            if (DbHelper.UserById(id, _connection) == null)
                return RedirectToPageNotFound();

            var viewModel = new ViewModel
            {
                Movies = DbHelper.MoviesListOrdered(_connection),
                Reviews = DbHelper.ReviewListDescById(id, _connection),
                UserById = DbHelper.UserById(id, _connection)
            };

            return View("UserProfile", viewModel);
        }

        [Authorize, HttpPost]
        public IActionResult ResetAvatar()
        {
            var user = DbHelper.UserById(CurrentUser().UserId, _connection);
            if (!DbHelper.IsUserExists(CurrentUser().UserId, _connection))
                return RedirectToPageNotFound();

            user.AvatarPath = "https://i.imgur.com/dNOjQWC.png";
            _connection.Update(user);

            return NoContent();
        }

        [Authorize, HttpPost]
        public IActionResult UpdateInformation(string nickname, string avatar)
        {
            var user = DbHelper.UserById(CurrentUser().UserId, _connection);
            if (!DbHelper.IsUserExists(CurrentUser().UserId, _connection))
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
            var user = DbHelper.UserById(CurrentUser().UserId, _connection);
            if (!DbHelper.IsUserExists(CurrentUser().UserId, _connection))
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
            if (!DbHelper.IsUserExists(CurrentUser().UserId, _connection))
                return RedirectToPageNotFound();

            var viewModel = new ViewModel
            {
                Movies = DbHelper.MoviesList(_connection),
                Reviews = DbHelper.ReviewListDescById(CurrentUser().UserId, _connection),
                UserById = DbHelper.UserById(CurrentUser().UserId, _connection)
            };

            return View(viewModel);
        }
    }
}