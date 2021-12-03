using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDataConnection _connection;
        public UserController(AppDataConnection connection) => _connection = connection;
        
        
        // GET
        public IActionResult UserProfile(Guid id)
        {
            if (id == Guid.Empty)
                return RedirectToAction("PageNotFound", "Home");

            var user = _connection.User.FirstOrDefault(x => x.UserId == id);
            return user == null ? RedirectToAction("PageNotFound", "Home") : View(user);
        }
        
        public IActionResult MyProfile() => View();
    }
}