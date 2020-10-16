using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.Repositories.ExercisesRepositories
{
	public class ExercisesRepositoryFake : IExercisesRepository
	{
		private List<Exercise> exercises;
		private readonly IReadOnlyList<Muscle> availableMuscles = new MusclesRepositories.MusclesRepositoryFake().Muscles;
		public IReadOnlyList<Exercise> Exercises
		{
			get
			{
				if (exercises is null)
				{
					exercises = new List<Exercise>()
					{
						new Exercise()
						{
							ID = 1,
							Name = "Pull-Up",
							Description = "Classic pull-up",
							UseMuscles = new List<Muscle>()
							{
								availableMuscles[0],
								availableMuscles[3]
							}
						},
						new Exercise()
						{
							ID = 2,
							Name = "Run",
							Description = "Simple run",
							UseMuscles = new List<Muscle>()
							{
								availableMuscles[1],
								availableMuscles[3]
							}
						},
						new Exercise()
						{
							ID = 3,
							Name = "Jog",
							Description = "Light jog",
							UseMuscles = new List<Muscle>()
							{
								availableMuscles[2],
								availableMuscles[3]
							}
						}
					};
				}

				return exercises;
			}
		}

		public bool Add(Exercise newExercise)
		{
			if (!Exercises.Contains(newExercise))
			{
				exercises.Add(newExercise);
				return true;
			}

			return false;
		}

		public bool Delete(Exercise exercise)
		{
			return exercises?.Remove(exercise) ?? false;
		}
	}
}
