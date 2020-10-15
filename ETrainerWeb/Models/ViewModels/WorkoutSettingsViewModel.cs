using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
		[Display(Name = "Используемые мышцы")]
		public List<int> IncludeMuscleses { get; set; }
		[Display(Name = "Исключаемые мышцы")]
		public List<int> ExcludeMuscleses { get; set; }
		public List<int> IncludeExercises { get; set; }
		public List<int> ExcludeExercises { get; set; }
	}
}
