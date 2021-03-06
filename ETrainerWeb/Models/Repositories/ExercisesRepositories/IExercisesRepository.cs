﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.Repositories.ExercisesRepositories
{
	public interface IExercisesRepository
	{
		IQueryable<Exercise> Exercises { get; }

		bool Add(Exercise newExercise);
		bool Delete(Exercise exercise);
		Task<bool> SaveAsync(Exercise exercise);
	}
}
