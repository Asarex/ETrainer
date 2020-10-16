using Microsoft.AspNetCore.Mvc;

namespace ETrainerWeb.Components
{
	public class UserInfoViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}