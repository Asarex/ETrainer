using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ETrainerWeb.Models
{
	public class User : IdentityUser
	{
		[Required]
		[MaxLength(30)]
		[Display(Name = "Login")]
		public override string UserName { get; set; }
	}
}
