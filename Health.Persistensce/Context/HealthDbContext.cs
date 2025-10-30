
using Health.Domain.Entitis.Users;
using Microsoft.EntityFrameworkCore;

namespace Health.Persistensce.Context
{
    public class HealthDbContext : DbContext
    {
        #region DbSet
        public DbSet<User> User { get; set; }
        #endregion


        public HealthDbContext(DbContextOptions contextOptions) : base(contextOptions) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base .OnModelCreating(modelBuilder);
        }
    }
}
