using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.Repositories
{
	public interface IMusclesRepository
	{
		IReadOnlyList<Muscle> Muscles { get; }
		bool Add(Muscle newMuscle);
		bool Delete(Muscle muscle);
	}
}
