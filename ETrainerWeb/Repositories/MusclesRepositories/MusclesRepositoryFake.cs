using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWebAPI.Models;

namespace ETrainerWebAPI.Repositories.MusclesRepositories
{
	public class MusclesRepositoryFake : IMusclesRepository
	{
		private List<Muscle> muscles;

		public IQueryable<Muscle> Muscles
		{
			get
			{
				if (muscles is null)
				{
					muscles = new List<Muscle>()
					{
						new Muscle {ID = 1, MuscleTranslatedInfos = new []{ new MuscleTranslatedInfo(){ Name = "Strong muscle", Description = "Very strong muscle"}}},
						new Muscle {ID = 1, MuscleTranslatedInfos = new []{ new MuscleTranslatedInfo(){ Name = "Weak muscle", Description = "Very weak muscle" } }},
						new Muscle {ID = 1, MuscleTranslatedInfos = new []{ new MuscleTranslatedInfo(){ Name = "Muscle", Description = "Ordinary muscle" } }},
						new Muscle {ID = 1, MuscleTranslatedInfos = new []{ new MuscleTranslatedInfo(){ Name = "Another muscle", Description = "Just another muscle" } }},
					};

				}
				return muscles.AsQueryable();
			}
		}

		public bool Add(Muscle newMuscle)
		{
			if (!Muscles.Contains(newMuscle))
			{
				newMuscle.ID = muscles.Count;
				muscles.Add(newMuscle);
				return true;
			}

			return false;
		}

		public bool Delete(Muscle muscle)
		{
			return muscles?.Remove(muscle) ?? false;
		}

		public async Task<bool> SaveAsync(Muscle muscle)
		{
			var originalMuscle = Muscles.FirstOrDefault(m => m.ID == muscle.ID);
			if (originalMuscle is null)
			{
				return false;
			}
			//originalMuscle.Name = muscle.Name;
			//originalMuscle.Description = muscle.Description;
			return true;
		}
	}
}
