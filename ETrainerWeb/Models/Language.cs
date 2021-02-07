using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETrainerWebAPI.Models
{
	public class Language
	{
		public int ID { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		public virtual ICollection<MuscleTranslatedInfo> MuscleTranslatedInfos { get; set; }

		public virtual ICollection<ExerciseTranslatedInfo> ExerciseTranslatedInfos { get; set; }
	}
}
