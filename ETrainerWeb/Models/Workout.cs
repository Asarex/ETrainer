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
			// Отберем упражнения для тех мышц которые хотим тренировать
			var exercisesForWorkout = new List<Exercise>();

			foreach (var exercise in exercises)
			{
				if (settings.ExcludeMuscleses != null && exercise.UseMuscles.Any(m => settings.ExcludeMuscleses.Contains(m)))
				{
					continue;
				}

				if (exercise.UseMuscles.Any(m => settings.IncludeMuscleses.Contains(m)))
				{
					exercisesForWorkout.Add(exercise);
				}
			}
			
			var workout = new Workout();
			workout.Name = settings.Name;
			workout.Exercises = new List<(Exercise exercise, int counts, int sets)>();
			workout.Exercises.AddRange(exercisesForWorkout.Select(e => (e, 10 , 3)));
			return workout;
		}
	}
}
