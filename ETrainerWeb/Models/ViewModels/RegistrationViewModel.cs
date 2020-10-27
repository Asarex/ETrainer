using System.ComponentModel.DataAnnotations;

namespace ETrainerWeb.Models.ViewModels
{
	public class RegistrationViewModel
	{
		[Required(ErrorMessage = "UserNameError")]
		[Display(Name = "UserName")]
		public string Name { get; set; }

		[Required(ErrorMessage = "PasswordError")]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required(ErrorMessage = "PasswordError")]
		[Compare("Password", ErrorMessage = "PasswordsDoNotMatch")]
		[DataType(DataType.Password)]
		[Display(Name = "RepeatPassword")]
		public string PasswordConfirm { get; set; }

		[Required(ErrorMessage = "EmailError")]
		[Display(Name = "Email")]
		public string Email { get; set; }

		public string ReturnUrl { get; set; }

	}
}
