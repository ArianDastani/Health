using System.ComponentModel.DataAnnotations;

namespace Health.Common.Enum
{
	public static class EnumExtensions
	{
		public static string GetDisplayName(this System.Enum enumValue)
		{
			var field = enumValue.GetType().GetField(enumValue.ToString());
			var attribute = (DisplayAttribute?)Attribute.GetCustomAttribute(field!, typeof(DisplayAttribute));
			return attribute?.Name ?? enumValue.ToString();
		}
	}
}
