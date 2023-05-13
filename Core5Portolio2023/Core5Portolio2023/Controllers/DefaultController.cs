using Microsoft.AspNetCore.Mvc;

namespace Core5Portolio2023.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
