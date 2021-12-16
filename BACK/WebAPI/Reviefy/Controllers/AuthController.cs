using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Reviefy.DataConnection;
using Reviefy.Models;
using Reviefy.Options;
using Reviefy.Security;
using Reviefy.Services;

namespace Reviefy.Controllers
{
    public class AuthController : Controller
    {
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly AppDataConnection _connection;
        
        public AuthController(IOptions<AuthOptions> options, AppDataConnection connection)
        {
            _authOptions = options;
            _connection = connection;
        }

        public IActionResult AuthStatus() => View();

        [HttpGet]
        public IActionResult Register() => View();

        [HttpGet]
        public IActionResult Login() => View();


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

            _connection.Insert(user);
            
            ViewBag.AuthStatus = "Successfully registered!";
            return View("AuthStatus");
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var pass = PassHashing.Encrypt(password);
            var user = AuthenticateUser(email, pass);
            if (user == null)
                return Unauthorized();

            var token = JwtGenerate(user);

            if (!HttpContext.Session.Keys.Contains("user"))
                HttpContext.Session.Set("user", user);


            if (!HttpContext.Request.Cookies.ContainsKey("name"))
                HttpContext.Response.Cookies.Append("jwt", token);

            ViewBag.AuthStatus =
                "Successfully logged in!";

            return View("AuthStatus");
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.Keys.Contains("user"))
                HttpContext.Session.Remove("user");

            if (!HttpContext.Request.Cookies.ContainsKey("name"))
                HttpContext.Response.Cookies.Delete("jwt");

            ViewBag.AuthStatus =
                "Successfully logged out!";
            return View("AuthStatus");
        }

        private User AuthenticateUser(string email, string password) =>
            _connection.User.FirstOrDefault(u => u.Email == email && u.Password == password);

        private User IsUserExist(string email) =>
            _connection.User.FirstOrDefault(u => u.Email == email);

        private string JwtGenerate(User user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Password),
            };

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}