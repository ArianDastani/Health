using System.ComponentModel.DataAnnotations;

namespace Health.Domain.Enum
{
	public class UserEnum
	{
		
		public enum UserTypeEnum
		{
			[Display(Name = "دکتر")]
			Doctor=1,
			[Display(Name = "بیمار")]
			Patient =2
		}
	}
}
