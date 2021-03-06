﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ETrainerWeb.Models.JoinModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ETrainerWeb.Models
{
	public class Muscle
	{
		[Required]
		public int ID { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		[Required]
		[MaxLength(200)]
		public string Description { get; set; }

		public virtual ICollection<MuscleExercise> MuscleExercises { get; set; }

		public virtual ICollection<WorkoutSettingsIncludeMuscles> IncludeInSettings { get; set; }
		public virtual ICollection<WorkoutSettingsExcludeMuscles> ExcludeFromSettings { get; set; }



		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			var m = (Muscle)obj;
			return Name == m.Name;
		}

		public static bool operator ==(Muscle left, Muscle right)
		{
			return left != null ? left.Equals(right) : right is null;
		}

		public static bool operator !=(Muscle left, Muscle right)
		{
			return !(left == right);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
