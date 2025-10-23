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
        public bool IsDeleted { get; set; }
        public string Ip { get; set; }
    }
}
