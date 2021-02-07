namespace ETrainerWebAPI.Models.JoinModels
{
	public class WorkoutSettingsExcludeMuscles
	{
		public WorkoutSettingsExcludeMuscles()
		{
		}

		public WorkoutSettingsExcludeMuscles(WorkoutSettings settings, Muscle muscle)
		{
			WorkoutSettingsID = settings.ID;
			WorkoutSettings = settings;
			MuscleID = muscle.ID;
			Muscle = muscle;
		}
		public int WorkoutSettingsID { get; set; }
		public int MuscleID { get; set; }
		public virtual WorkoutSettings WorkoutSettings { get; set; }
		public virtual Muscle Muscle { get; set; }
	}
}
