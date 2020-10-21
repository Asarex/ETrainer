using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ETrainerWeb.Attributes;

namespace ETrainerWeb.Models.ViewModels
{
	public class WorkoutSettingsViewModel
	{
		[Required]
		[Display(Name = "Название настроек тренировки")]
		public string Name { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required]
		[NotEmptyEnumerable]
		[Display(Name = "Используемые мышцы")]
		public List<int> IncludeMuscleses { get; set; } = new List<int>();
		[Display(Name = "Исключаемые мышцы")]
		public List<int> ExcludeMuscleses { get; set; } = new List<int>();
		public List<int> IncludeExercises { get; set; }
		public List<int> ExcludeExercises { get; set; }
	}
}
