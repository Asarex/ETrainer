using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ETrainerWeb.Attributes;

namespace ETrainerWeb.Models.ViewModels
{
	public class WorkoutSettingsViewModel
	{
		[Required(ErrorMessage = "NameError")]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required(ErrorMessage = "IncludeMusclesError")]
		[NotEmptyEnumerable]
		[Display(Name = "IncludeMuscles")]
		public List<int> IncludeMuscleses { get; set; } = new List<int>();
		[Display(Name = "ExcludeMuscles")]
		public List<int> ExcludeMuscleses { get; set; } = new List<int>();
		public List<int> IncludeExercises { get; set; }
		public List<int> ExcludeExercises { get; set; }
	}
}
