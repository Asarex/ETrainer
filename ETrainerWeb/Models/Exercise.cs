using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ETrainerWebAPI.Models.JoinModels;

namespace ETrainerWebAPI.Models
{
	public class Exercise
	{
		[Required]
		public int ID { get; set; }

		public virtual ICollection<ExerciseTranslatedInfo> ExerciseTranslatedInfos { get; set; }
		
		[Required]
		public virtual ICollection<MuscleExercise> MuscleExercises { get; set; } = new List<MuscleExercise>();

		[NotMapped]
		public ICollection<Muscle> UseMuscles
		{
			get { return MuscleExercises.Select(me => me.Muscle).ToList(); }
			set
			{
				MuscleExercises = value.Select(muscle => new MuscleExercise() {Exercise = this, ExerciseID = ID, Muscle = muscle, MuscleID = muscle.ID}).ToList();
			}
		}
	}
}
