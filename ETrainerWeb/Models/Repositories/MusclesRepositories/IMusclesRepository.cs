using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.Repositories
{
	public interface IMusclesRepository
	{
		IQueryable<Muscle> Muscles { get; }
		bool Add(Muscle newMuscle);
		bool Delete(Muscle muscle);
		Task<bool> SaveAsync(Muscle muscle);
	}
}
