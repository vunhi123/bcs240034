using Microsoft.AspNetCore.Mvc;
using MID_BCS240034.Models;
using MID_BCS240034.Data;
using System.Diagnostics;
using System.Linq;

namespace MID_BCS240034.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Load up to 3 images to show on homepage
            var images = _context.EventImages_BCS240034
                .Select(i => i.ImageUrl)
                .Take(3)
                .ToList();

            return View(images);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
