using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Reviefy.Models;
using Reviefy.Options;
using Reviefy.Security;

namespace Reviefy.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
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
                AvatarPath = ""
            };
            
            _connection.Insert(user);

           // return Ok("Registered");
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

            //return Ok($"access_token= {token}\nemail = {email}\npassword = {password}");

            ViewBag.AuthStatus = $"Successfully logged in!";//\naccess_token= {token}\nemail = {email}\npassword = {password}";
            return View("AuthStatus");
        }

        // [Route("registration")]
        // [HttpPost]
        // public IActionResult Registration([FromBody] RegRequest request)
        // {
        //     //try to Authenticate User
        //     var user = IsUserExist(request.Email);
        //     if (user != null)
        //     {
        //         return Ok("This account already exists");
        //     }
        //
        //     user = new User
        //     {
        //         UserId = Guid.NewGuid(),
        //         Email = request.Email,
        //         Password = PassHashing.Encrypt(request.Password),
        //         //Role = "User",
        //         Nickname = request.Nickname,
        //         RegisterDate = DateTime.Now,
        //         AvatarPath = ""
        //     };
        //
        //     _connection.Insert(user);
        //
        //     return Ok("Registered");
        // }
        //
        //
        // [Route("login")]
        // [HttpPost]
        // public IActionResult Login([FromBody] AuthRequest request)
        // {
        //     var pass = PassHashing.Encrypt(request.Password);
        //     var user = AuthenticateUser(request.Email, pass);
        //     if (user == null)
        //         return Unauthorized();
        //
        //     var token = JwtGenerate(user);
        //     return Ok(new
        //     {
        //         access_token = token,
        //         request.Email,
        //         request.Password,
        //     });
        // }


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