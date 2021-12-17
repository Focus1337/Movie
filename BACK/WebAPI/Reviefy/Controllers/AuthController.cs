using System;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Attributes;
using Reviefy.Models;
using Reviefy.Repository;
using Reviefy.Security;
using Reviefy.Services;

namespace Reviefy.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDataConnection _connection;

        public AuthController(AppDataConnection connection)
        {
            _connection = connection;
        }

        public IActionResult AuthStatus() => View();

        [HttpGet]
        public IActionResult Register() => View();

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var pass = PassHashing.Encrypt(password);
            var user = DbHelper.AuthenticateUser(email, pass, _connection);
            if (user == null)
                return BadRequest();

            var token = JwtGenerator.GenerateJwtToken(user.UserId);

            HttpContext.Response.Cookies.Append("Authorization", token);

            ViewBag.AuthStatus =
                "Successfully logged in!";

            return View("AuthStatus");
        }

        [HttpPost]
        public IActionResult Register(string nickname, string email,
            string password, string confirmPassword)
        {
            //try to Authenticate User
            var user = DbHelper.UserByEmail(email, _connection);
            if (user != null)
                return Ok("This account already exists");

            if (password != confirmPassword)
                return Ok("Password differs");

            user = new User
            {
                UserId = Guid.NewGuid(),
                Email = email,
                Password = PassHashing.Encrypt(password),
                Nickname = nickname,
                RegisterDate = DateTime.Now,
                AvatarPath = "https://i.imgur.com/dNOjQWC.png"
            };

            var token = JwtGenerator.GenerateJwtToken(user.UserId);

            _connection.Insert(user);
            HttpContext.Response.Cookies.Append("Authorization", token);
            
            Console.WriteLine("registration:" + token);

            ViewBag.AuthStatus = "Successfully registered!";
            return View("AuthStatus");
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("Authorization");

            ViewBag.AuthStatus =
                "Successfully logged out!";
            return View("AuthStatus");
        }
    }
}