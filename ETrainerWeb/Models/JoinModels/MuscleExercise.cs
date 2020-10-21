using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.JoinModels
{
	public class MuscleExercise
	{
		public MuscleExercise()
		{
		}

		public MuscleExercise(Exercise exercise, Muscle muscle)
		{
			Muscle = muscle;
			MuscleID = muscle.ID;
			Exercise = exercise;
			ExerciseID = exercise.ID;
		}
		public int MuscleID { get; set; }
		public virtual Muscle Muscle { get; set; }
		public int ExerciseID { get; set; }
		public virtual Exercise Exercise { get; set; }
	}
}
