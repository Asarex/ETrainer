using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ETrainerWebAPI.Models.JoinModels;

namespace ETrainerWebAPI.Models
{
	public class Muscle
	{
		[Required]
		public int ID { get; set; }

		public virtual ICollection<MuscleTranslatedInfo> MuscleTranslatedInfos { get; set; }
		
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
			return ID == m.ID;
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
			return ID.GetHashCode();
		}
	}
}
