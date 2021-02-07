using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWebAPI.Models.Repositories.WorkoutSettingsRepositories
{
	public class WorkoutSettingsRepositoryFake : IWorkoutSettingsRepository
	{
		private List<WorkoutSettings> workoutSettings;

		public IQueryable<WorkoutSettings> WorkoutSettings => (workoutSettings ??= new List<WorkoutSettings>()).AsQueryable();

		public bool Add(WorkoutSettings newSettings)
		{
			if (!WorkoutSettings.Contains(newSettings))
			{
				workoutSettings.Add(newSettings);
				return true;
			}

			return false;
		}

		public bool Delete(WorkoutSettings settings)
		{
			return workoutSettings?.Remove(settings) ?? false;
		}

		public Task<bool> SaveAsync(WorkoutSettings settings)
		{
			throw new System.NotImplementedException();
		}
	}
}
