using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWeb.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			object model = "Home";
			return View(model);
		}
	}
}
