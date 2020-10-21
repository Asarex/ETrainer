using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWeb.Models.DbContexts;
using ETrainerWeb.Models.Repositories.ExercisesRepositories;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWeb.Models.Repositories.MusclesRepositories
{
	public class ExercisesRepository : IExercisesRepository
	{
		private readonly AppDbContext dbContext;
		public ExercisesRepository(AppDbContext context)
		{
			dbContext = context;
		}

		public IQueryable<Exercise> Exercises => dbContext.Exercises;
		public bool Add(Exercise newExercise)
		{
			newExercise.ID = 0;
			dbContext.Exercises.Add(newExercise);
			dbContext.SaveChanges();
			return true;
		}

		public bool Delete(Exercise exercise)
		{
			dbContext.Exercises.Remove(exercise);
			dbContext.SaveChanges();
			return true;
		}

		public async Task<bool> SaveAsync(Exercise exercise)
		{
			var oldExercise = await dbContext.Exercises.FindAsync(exercise.ID);
			if (oldExercise is null)
			{
				return false;
			}

			oldExercise.Name = exercise.Name;
			oldExercise.Description = exercise.Description;
			oldExercise.UseMuscles = exercise.UseMuscles;
			dbContext.SaveChanges();
			return true;
		}
	}
}
