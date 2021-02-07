using System.Linq;
using System.Threading.Tasks;
using ETrainerWebAPI.Models.DbContexts;

namespace ETrainerWebAPI.Models.Repositories.ExercisesRepositories
{
	public class ExercisesRepository : IExercisesRepository
	{
		private readonly ETrainerDbContext dbContext;
		public ExercisesRepository(ETrainerDbContext context)
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

			//oldExercise.Name = exercise.Name;
			//oldExercise.Description = exercise.Description;
			oldExercise.UseMuscles = exercise.UseMuscles;
			dbContext.SaveChanges();
			return true;
		}
	}
}
