using Health.Domain.Entitis.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Health.Persistensce.Configuratin
{
    public class UserConfig:IEntityTypeConfiguration<User>
    {
     

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                UniqueId = new Guid(),
                FirstName = "Admin",
                LastName = "Health",
                IsActive = true,
                IsDeleted = false,
                PasswordHash = "HealthP@ssw0rd",
                UserName = "Admin-Health",
                CreatedOn = DateTime.Now,
                IsAdmin = true
            });
        }
    }
}
