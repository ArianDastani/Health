using Health.Persistensce.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Health.Persistensce.Extention
{
    public static class ServiseCollection
    {
        public static void AddDataLeyer(this IServiceCollection services)
        {
            services.AddConfig();
        }

        public static void AddConfig(this IServiceCollection services)
        {
            services.AddDbContext<HealthDbContext>(op =>
            {
                op.UseSqlServer("Date Source=.;initiol catalog=HealthDb;Integertaed security=true;TrustServerCertificate=True;");
            });
        }
    }
}
