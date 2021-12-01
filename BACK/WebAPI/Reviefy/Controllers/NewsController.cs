using Microsoft.AspNetCore.Mvc;

namespace Reviefy.Controllers
{
    public class NewsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }
        
        public IActionResult NewsDetail()
        {
            return View();
        }
    }
}