using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models
{
	public class WorkoutSettings
	{
		[Required]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required]
		public ICollection<Muscle> IncludeMuscleses { get; set; }
		public ICollection<Muscle> ExcludeMuscleses { get; set; }
		public ICollection<Muscle> IncludeExercises { get; set; }
		public ICollection<Muscle> ExcludeExercises { get; set; }
	}
}
