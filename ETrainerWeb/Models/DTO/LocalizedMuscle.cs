using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWebAPI.Models.DTO
{
	public class LocalizedMuscle
	{
		[MaxLength(30)]
		[Required]
		public string Name { get; set; }

		[MaxLength(150)]
		[Required]
		public string Description { get; set; }

		public int LanguageId { get; set; }
	}
}
