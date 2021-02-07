﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWebAPI.Models;

namespace ETrainerWebAPI.Repositories.ExercisesRepositories
{
	public class ExercisesRepositoryFake : IExercisesRepository
	{
		private List<Exercise> _exercises;
		private readonly IReadOnlyList<Muscle> availableMuscles = new MusclesRepositories.MusclesRepositoryFake().Muscles.ToList();
		public IQueryable<Exercise> Exercises
		{
			get
			{
				if (_exercises is null)
				{
					_exercises = new List<Exercise>()
					{
						new Exercise()
						{
							ID = 1,
							
							UseMuscles = new List<Muscle>()
							{
								availableMuscles[0],
								availableMuscles[3]
							},
							ExerciseTranslatedInfos = new []
							{
								new ExerciseTranslatedInfo(){Name = "Pull-Up", Description = "Classic pull-up",}
							}
						},
						new Exercise()
						{
							ID = 2,
							UseMuscles = new List<Muscle>()
							{
								availableMuscles[1],
								availableMuscles[3]
							},
							ExerciseTranslatedInfos = new []
							{
								new ExerciseTranslatedInfo(){Name = "Run", Description = "Simple run",}
							}
						},
						new Exercise()
						{
							ID = 3,
							UseMuscles = new List<Muscle>()
							{
								availableMuscles[2],
								availableMuscles[3]
							},
							ExerciseTranslatedInfos = new []
							{
								new ExerciseTranslatedInfo(){Name = "Jog", Description = "Light jog",}
							}
						}
					};
				}

				return _exercises.AsQueryable();
			}
		}

		public bool Add(Exercise newExercise)
		{
			if (!Exercises.Contains(newExercise))
			{
				_exercises.Add(newExercise);
				return true;
			}

			return false;
		}

		public bool Delete(Exercise exercise)
		{
			return _exercises?.Remove(exercise) ?? false;
		}

		public async Task<bool> SaveAsync(Exercise exercise)
		{
			var oldExercise = _exercises.FirstOrDefault(e => e.ID == exercise.ID);
			if (oldExercise is null)
			{
				return false;
			}

			//oldExercise.Name = exercise.Name;
			//oldExercise.Description = exercise.Description;
			oldExercise.UseMuscles = exercise.UseMuscles;
			return true;
		}
	}
}
