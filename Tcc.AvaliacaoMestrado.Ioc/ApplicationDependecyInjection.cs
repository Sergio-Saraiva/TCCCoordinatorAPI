using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Tcc.AvaliacaoMestrado.Data.Repositories;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Ioc
{
    public static class ApplicationDependecyInjection
    {
        public static void AddApplicationDependecyInjection(this IServiceCollection services)
        {

            services.AddSingleton(Log.Logger);

            services.AddScoped<IFormsRepository, FormsRepository>();
        }
    }
}
