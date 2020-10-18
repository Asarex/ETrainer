using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETrainerWeb.Models
{
	public class WorkoutSettings
	{
		[Required]
		public int ID { get; set; }
		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required]
		public ICollection<Muscle> IncludeMuscleses { get; set; } = new List<Muscle>();
		public ICollection<Muscle> ExcludeMuscleses { get; set; } = new List<Muscle>();
		public ICollection<Muscle> IncludeExercises { get; set; } = new List<Muscle>();
		public ICollection<Muscle> ExcludeExercises { get; set; } = new List<Muscle>();
	}
}
