
using Health.Domain.Base;
using System.Collections.Specialized;

namespace Health.Domain.Entitis.Users
{
    public class User:BaseEntity
    {
        
        public string NationalId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public string? UserName { get; set; }

        public string? Bio { get; set; }
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



    }
}
