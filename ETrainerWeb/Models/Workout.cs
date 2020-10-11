using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models
{
	public class Workout
	{
		public string Name { get; set; }
		public List<(Exercise exercise, int counts, int sets)> Exercises { get; set; }

		public static Workout GenerateWorkout(WorkoutSettings settings, IReadOnlyList<Exercise> exercises)
		{
			var workout = new Workout();
			workout.Name = settings.Name;
			workout.Exercises = new List<(Exercise exercise, int counts, int sets)>();
			workout.Exercises.AddRange(exercises.Select(e => (e, 1 ,1)));
			return workout;
		}
	}
}
