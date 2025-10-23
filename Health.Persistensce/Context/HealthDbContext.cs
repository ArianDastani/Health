
using Microsoft.EntityFrameworkCore;

namespace Health.Persistensce.Context
{
    public class HealthDbContext : DbContext
    {
        public HealthDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base .OnModelCreating(modelBuilder);
        }
    }
}
