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
		public string Name { get; set; }

		[Required]
		public List<string> IncludeMuscleses { get; set; }
		public List<string> ExcludeMuscleses { get; set; }
		public List<Exercise> IncludeExercises { get; set; }
		public List<Exercise> ExcludeExercises { get; set; }
	}
}
