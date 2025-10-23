using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Domain.Base
{
    public class BaseEntity
    {
        public Guid UniqueId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get;set; }

        public bool IsActive { get; set; }

        public string? CreatedUserIp { get; set; }

        public string? DeletedUserHostName { get; set; }

        public string? DeletedUserIp { get; set; }

        public bool IsDeleted { get; set; }

     
    }
}
