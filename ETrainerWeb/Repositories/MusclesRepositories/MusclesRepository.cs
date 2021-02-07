using System.Linq;
using System.Threading.Tasks;
using ETrainerWebAPI.Models;
using ETrainerWebAPI.Models.DbContexts;

namespace ETrainerWebAPI.Repositories.MusclesRepositories
{
	public class MusclesRepository : IMusclesRepository
	{
		private readonly ETrainerDbContext dbContext;
		public MusclesRepository(ETrainerDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IQueryable<Muscle> Muscles => dbContext.Muscles;
		public bool Add(Muscle newMuscle)
		{
			newMuscle.ID = 0;
			dbContext.Muscles.Add(newMuscle);
			dbContext.SaveChanges();
			return true;
		}

		public bool Delete(Muscle muscle)
		{
			dbContext.Muscles.Remove(muscle);
			dbContext.SaveChanges();
			return true;
		}

		public async Task<bool> SaveAsync(Muscle muscle)
		{
			var oldMuscle = await dbContext.Muscles.FindAsync(muscle.ID);
			if (oldMuscle is null)
			{
				return false;
			}

			//oldMuscle.Name = muscle.Name;
			//oldMuscle.Description = muscle.Description;
			dbContext.SaveChanges();
			return true;
		}
	}
}
