using Microsoft.AspNetCore.Mvc;

namespace ETrainerWeb.Components
{
	public class SelectLocalizationViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var options = new[] {"ru", "eng"};
			return View(options);
		}
	}
}