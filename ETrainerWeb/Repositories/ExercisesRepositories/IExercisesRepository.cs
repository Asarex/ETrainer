using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWebAPI.Models.Repositories.ExercisesRepositories
{
	public interface IExercisesRepository
	{
		IQueryable<Exercise> Exercises { get; }

		bool Add(Exercise newExercise);
		bool Delete(Exercise exercise);
		Task<bool> SaveAsync(Exercise exercise);
	}
}
