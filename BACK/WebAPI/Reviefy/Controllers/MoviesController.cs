using Microsoft.AspNetCore.Mvc;

namespace Reviefy.Controllers
{
    public class MoviesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View("MovieDetail");
        }
    }
}