using System;
using System.Linq;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.DataConnection;
using Reviefy.Models;
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
            var user = AuthenticateUser(email, pass);
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
            var user = IsUserExist(email);
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

        public IActionResult Logout()
        {
            //if (!HttpContext.Request.Cookies.ContainsKey("Authorization"))
            HttpContext.Response.Cookies.Delete("Authorization");

            ViewBag.AuthStatus =
                "Successfully logged out!";
            return View("AuthStatus");
        }

        private User AuthenticateUser(string email, string password) =>
            _connection.User.FirstOrDefault(u => u.Email == email && u.Password == password);

        private User IsUserExist(string email) =>
            _connection.User.FirstOrDefault(u => u.Email == email);
    }
}