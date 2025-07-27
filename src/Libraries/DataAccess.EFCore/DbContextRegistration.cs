using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.EFCore
{
    public static class DbContextRegistration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("AppDb");
            return services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(connectionString));
        }
    }
}
