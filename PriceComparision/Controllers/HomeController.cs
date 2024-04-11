using Microsoft.AspNetCore.Mvc;
using PriceComparision.Data;
using PriceComparision.Models;
using System.Diagnostics;

namespace PriceComparision.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {            
            return View();
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

		[HttpGet]
		public IActionResult Search(string phrase)
		{
			IEnumerable<Product> products = _db.Products
                .Where(x => x.Category == phrase)
                .OrderBy(x => x.Price)
                .ToList();

            return View(products);
		}
	}
}
