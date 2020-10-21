using System.Collections;
using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;

namespace ETrainerWeb.Attributes
{
	public class NotEmptyEnumerable : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value is IEnumerable enumerable)
			{
				return !enumerable.IsNullOrEmpty();
			}

			return true;
		}
	}
}