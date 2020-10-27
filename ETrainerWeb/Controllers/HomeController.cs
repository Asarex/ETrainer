using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWeb.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult SetLocalization(string culture, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
			);
			return Redirect(returnUrl);
		}

		public IActionResult Index()
		{
			object model = CultureInfo.CurrentCulture.Name;
			return View(model);
		}
	}
}
