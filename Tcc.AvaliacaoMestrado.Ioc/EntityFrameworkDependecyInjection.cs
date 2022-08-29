using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tcc.AvaliacaoMestrado.Data.Context;
using Tcc.AvaliacaoMestrado.Shared.AppSettings;

namespace Tcc.AvaliacaoMestrado.Ioc
{
    public static class EntityFrameworkDependecyInjection
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
    }
}
