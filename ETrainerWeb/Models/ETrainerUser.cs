using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ETrainerWebAPI.Models
{
	public class ETrainerUser : IdentityUser
	{
		[Required]
		[MaxLength(30)]
		public string DisplayedName { get; set; }
	}
}
