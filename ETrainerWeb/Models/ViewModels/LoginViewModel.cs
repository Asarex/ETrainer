using System.ComponentModel.DataAnnotations;

namespace ETrainerWeb.Models.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "LoginError")]
		[Display(Name = "Login")]
		public string Login { get; set; }

		[Required(ErrorMessage = "PasswordError")]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Remember")]
		public bool RememberMe { get; set; }

		public string ReturnUrl { get; set; }
	}
}
