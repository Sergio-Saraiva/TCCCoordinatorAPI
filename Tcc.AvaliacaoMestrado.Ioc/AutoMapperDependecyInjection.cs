using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tcc.AvaliacaoMestrado.Application.AutoMapper;

namespace Tcc.AvaliacaoMestrado.Ioc
{
    public static class AutoMapperDependecyInjection
    {
        public static void AddAutoMapperConfigureServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping();
            }, typeof(MappingProfile).GetTypeInfo().Assembly);
        }
    }
}
