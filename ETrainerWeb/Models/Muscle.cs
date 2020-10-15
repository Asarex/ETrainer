using System.ComponentModel.DataAnnotations;

namespace ETrainerWeb.Models
{
	public class Muscle
	{
		[Required]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			var m = (Muscle)obj;
			return ID == m.ID;
		}

		public static bool operator ==(Muscle left, Muscle right)
		{
			if (left is null && right is null)
			{
				return true;
			}
			return left?.Equals(right) ?? false;
		}

		public static bool operator !=(Muscle left, Muscle right)
		{
			return !(left == right);
		}

		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}
	}
}
