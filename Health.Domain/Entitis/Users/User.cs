using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Health.Domain.Base;
using Health.Domain.Enum;

namespace Health.Domain.Entitis.Users
{
	[DisplayName("کاربران")]
	[Table(name: "User", Schema = "Health")]
    public class User:BaseEntity
    {
		#region Propertis
		[Key]
		public Guid UniqueId { get; set; }
		//[Display(Name = nameof(Resources.Resource.NationalId), ResourceType = typeof(Resources.Resource))]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Code { get; set; }
		public string NationalCode { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string PasswordHash { get; set; }
		public string UserName { get; set; }
		public string Bio { get; set; }
        public bool IsAdmin { get; set; }
        public UserEnum.UserTypeEnum UserType { get; set; }

		#endregion

		#region Relation


		/// <summary>
		/// we must have class for them later
		////so they are some kide of class and reprasenting for
		///relations
		//public string proFile { get; set; }
		//public string Note { get; set; }
		//public string History { get; set; }
		//public string Academic { get; set; }
		//public string Contact { get; set; }
		/// </summary>


		#endregion

	}
}
