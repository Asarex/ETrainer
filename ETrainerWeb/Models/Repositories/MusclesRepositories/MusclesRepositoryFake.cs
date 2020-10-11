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
						new Muscle(){Name = "Strong muscle", Description = "Very strong muscle"},
						new Muscle(){Name = "Weak muscle", Description = "Very weak muscle"},
						new Muscle(){Name = "Muscle", Description = "Ordinary muscle"},
						new Muscle(){Name = "Another muscle", Description = "Just another muscle"},
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
