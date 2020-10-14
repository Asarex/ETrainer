using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.Repositories.WorkoutSettingsRepositories
{
	public interface IWorkoutSettingsRepository
	{
		IReadOnlyList<WorkoutSettings> WorkoutSettings { get; }
		bool Add(WorkoutSettings newSettings);
		bool Delete(WorkoutSettings settings);
	}
}
