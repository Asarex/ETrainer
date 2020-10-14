using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models.Repositories.MusclesRepositories
{
	public class MusclesRepositoryFake : IMusclesRepository
	{
		private List<Muscle> muscles;

		public IReadOnlyList<Muscle> Muscles
		{
			get
			{
				if (muscles is null)
				{
					muscles = new List<Muscle>()
					{
						new Muscle(){ID = 1,Name = "Strong muscle", Description = "Very strong muscle"},
						new Muscle(){ID = 2, Name = "Weak muscle", Description = "Very weak muscle"},
						new Muscle(){ID = 3, Name = "Muscle", Description = "Ordinary muscle"},
						new Muscle(){ID = 4, Name = "Another muscle", Description = "Just another muscle"},
					};

				}
				return muscles;
			}
		}

		public bool Add(Muscle newMuscle)
		{
			if (!Muscles.Contains(newMuscle))
			{
				muscles.Add(newMuscle);
				return true;
			}

			return false;
		}

		public bool Delete(Muscle muscle)
		{
			return muscles?.Remove(muscle) ?? false;
		}
	}
}
