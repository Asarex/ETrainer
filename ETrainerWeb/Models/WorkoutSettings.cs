using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ETrainerWeb.Models.JoinModels;

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
		[MaxLength(30)]
		public string UserName { get; set; }

		[Required]
		public virtual ICollection<WorkoutSettingsIncludeMuscles> WorkoutSettingsIncludeMuscleses { get; set; } = new List<WorkoutSettingsIncludeMuscles>();

		[NotMapped]
		public virtual ICollection<Muscle> IncludeMuscleses {
			get { return WorkoutSettingsIncludeMuscleses.Select(wi => wi.Muscle).ToList(); }
			set
			{
				WorkoutSettingsIncludeMuscleses =
					value.Select(m => new WorkoutSettingsIncludeMuscles(this, m)).ToList();
			}
		}

		public virtual ICollection<WorkoutSettingsExcludeMuscles> WorkoutSettingsExcludeMuscles { get; set; } = new List<WorkoutSettingsExcludeMuscles>();

		[NotMapped]
		public virtual ICollection<Muscle> ExcludeMuscleses
		{
			get { return WorkoutSettingsExcludeMuscles.Select(wi => wi.Muscle).ToList(); }
			set
			{
				WorkoutSettingsExcludeMuscles =
					value.Select(m => new WorkoutSettingsExcludeMuscles(this, m)).ToList();
			}
		}
		/*[NotMapped]
		public virtual ICollection<Muscle> IncludeExercises { get; set; } = new List<Muscle>();
		[NotMapped]
		public virtual ICollection<Muscle> ExcludeExercises { get; set; } = new List<Muscle>();*/
	}
}
