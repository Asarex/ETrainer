using System.ComponentModel.DataAnnotations;

namespace ETrainerWebAPI.Models
{
	public class MuscleTranslatedInfo
	{
		public int ID { get; set; }
		
		[Required]
		public virtual Language Language { get; set; }

		[MaxLength(30)]
		[Required]
		public string Name { get; set; }

		[MaxLength(150)]
		[Required]
		public string Description { get; set; }

		public virtual Muscle Muscle { get; set; }
	}
}
