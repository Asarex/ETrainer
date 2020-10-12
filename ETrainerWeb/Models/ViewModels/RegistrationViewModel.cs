using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ETrainerWeb.Models.ViewModels
{
	public class RegistrationViewModel
	{
		[Required]
		[Display(Name = "Имя пользователя")]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[Required]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		[DataType(DataType.Password)]
		[Display(Name = "Подтвердите пароль")]
		public string PasswordConfirm { get; set; }

		[Required]
		public string Email { get; set; }

	}
}
