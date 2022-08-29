using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tcc.AvaliacaoMestrado.Application.Pipelines;

namespace Tcc.AvaliacaoMestrado.Ioc
{
    public static class MediatRDependecyInjection
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            var myHandlers = AppDomain.CurrentDomain.Load("Tcc.AvaliacaoMestrado.Application");
            services.AddMediatR(myHandlers);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionPipelineBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingRequestBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
        }
    }
}
