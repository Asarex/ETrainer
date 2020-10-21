using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ETrainerWeb.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ETrainerWeb.Models.ViewModels
{
	public class EditExerciseViewModel
	{
		public EditExerciseViewModel()
		{
			UseMuscles = new List<int>();
		}

		public EditExerciseViewModel(Exercise exercise)
		{
			ID = exercise.ID;
			Name = exercise.Name;
			Description = exercise.Description;
			UseMuscles = exercise.UseMuscles.Select(m => m.ID).ToList();
		}

		[Required]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		[NotEmptyEnumerable]
		public List<int> UseMuscles { get; set; }

		[BindNever]
		public IQueryable<Muscle> AllMuscles { get; set; }
	}
}
