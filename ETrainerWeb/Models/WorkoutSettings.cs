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
		public IEnumerable<int> IncludeMuscleses { get; set; }
		public IEnumerable<int> ExcludeMuscleses { get; set; }
		public IEnumerable<int> IncludeExercises { get; set; }
		public IEnumerable<int> ExcludeExercises { get; set; }
	}
}
