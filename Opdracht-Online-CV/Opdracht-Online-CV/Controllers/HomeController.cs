using Microsoft.AspNetCore.Mvc;
using Opdracht_Online_CV.Models;
using System.Diagnostics;

namespace Opdracht_Online_CV.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AboutMe()
		{
			return View();
		}
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Contact()
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