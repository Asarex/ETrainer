namespace ETrainerWebAPI.Models.JoinModels
{
	public class MuscleExercise
	{
		public MuscleExercise()
		{
		}

		public int MuscleID { get; set; }
		public virtual Muscle Muscle { get; set; }
		public int ExerciseID { get; set; }
		public virtual Exercise Exercise { get; set; }
	}
}
