using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWebAPI.Models.Repositories.MusclesRepositories
{
	public interface IMusclesRepository
	{
		IQueryable<Muscle> Muscles { get; }
		bool Add(Muscle newMuscle);
		bool Delete(Muscle muscle);
		Task<bool> SaveAsync(Muscle muscle);
	}
}
