using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
	public class DemoController : Controller
	{
		public IActionResult Test()
		{
			ViewData["Message"] = "hey hoe dit is een viewdata bericht";
			ViewBag.Bericht = "dit is een viewbag bericht";
			return View();
		}
	}
}
