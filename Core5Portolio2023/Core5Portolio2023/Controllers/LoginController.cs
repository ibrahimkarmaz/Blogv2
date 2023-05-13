using Microsoft.AspNetCore.Mvc;

namespace Core5Portolio2023.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
	}
}
