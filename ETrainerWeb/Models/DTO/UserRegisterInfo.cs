using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWebAPI.Models.DTO
{
	public class UserRegisterInfo
	{
		[Required]
		[StringLength(30, MinimumLength = 5)]
		public string Login { get; set; }
		[Required]
		[StringLength(30, MinimumLength = 5)]
		public string Password { get; set; }
		[Required]
		[MaxLength(30)]
		public string DisplayName { get; set; }
		[Required]
		[MaxLength(50)]
		public string Email { get; set; }
	}
}
