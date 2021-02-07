using System.ComponentModel.DataAnnotations;

namespace ETrainerWebAPI.Models
{
	public class ExerciseTranslatedInfo
	{
		public int ID { get; set; }
		
		[Required]
		public virtual Language Language { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		[Required]
		[MaxLength(200)]
		public string Description { get; set; }

		public virtual Exercise Exercise { get; set; }
	}
}
