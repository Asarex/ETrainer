using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.Repositories.WorkoutSettingsRepositories
{
	public class WorkoutSettingsRepositoryFake : IWorkoutSettingsRepository
	{
		private List<WorkoutSettings> workoutSettings;

		public IReadOnlyList<WorkoutSettings> WorkoutSettings
		{
			get { return workoutSettings ?? (workoutSettings = new List<WorkoutSettings>()); }
		}

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
	}
}
