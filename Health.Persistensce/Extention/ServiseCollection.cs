using Health.Persistensce.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Health.Persistensce.Extention
{
    public static class ServiseCollection
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfig(configuration);
        }

        public static void AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HealthDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            });
        }
    }
}
