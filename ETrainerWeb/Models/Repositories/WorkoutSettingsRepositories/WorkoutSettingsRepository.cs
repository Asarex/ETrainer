using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWeb.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWeb.Models.Repositories.WorkoutSettingsRepositories
{
	public class WorkoutSettingsRepository : IWorkoutSettingsRepository
	{
		private readonly AppDbContext dbContext;

		public WorkoutSettingsRepository(AppDbContext context)
		{
			dbContext = context;
		}

		public IQueryable<WorkoutSettings>WorkoutSettings => dbContext.WorkoutSettingses;
			
		public bool Add(WorkoutSettings newSettings)
		{
			newSettings.ID = 0;
			dbContext.Add(newSettings);
			dbContext.SaveChanges();
			return true;
		}

		public bool Delete(WorkoutSettings settings)
		{
			dbContext.Remove(settings);
			dbContext.SaveChanges();
			return true;
		}

		public async Task<bool> SaveAsync(WorkoutSettings settings)
		{
			var oldSettings = await dbContext.WorkoutSettingses.FindAsync(settings.ID);
			if (oldSettings is null)
			{
				return false;
			}

			oldSettings.Name = settings.Name;
			oldSettings.UserName = settings.UserName;
			oldSettings.WorkoutSettingsExcludeMuscles = settings.WorkoutSettingsExcludeMuscles;
			oldSettings.WorkoutSettingsIncludeMuscleses = settings.WorkoutSettingsIncludeMuscleses;
			dbContext.SaveChanges();
			return true;
		}
	}
}
