﻿using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.Repositories.WorkoutSettingsRepositories
{
	public interface IWorkoutSettingsRepository
	{
		IQueryable<WorkoutSettings> WorkoutSettings { get; }
		bool Add(WorkoutSettings newSettings);
		bool Delete(WorkoutSettings settings);

		Task<bool> SaveAsync(WorkoutSettings settings);
	}
}
