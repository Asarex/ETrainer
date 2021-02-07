using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWebAPI.Models.DTO
{
	public class LanguageInfo
	{
		[Required]
		[MaxLength(30)]
		public string Language { get; set; }
		public int LanguageId { get; set; }
	}
}
