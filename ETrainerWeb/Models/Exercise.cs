using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETrainerWeb.Models
{
	public class Exercise
	{
		[Required]
		public int ID { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		[Required]
		[MaxLength(200)]
		public string Description { get; set; }

		[Required]
		public ICollection<Muscle> UseMuscles { get; set; } = new List<Muscle>();
	}
}
