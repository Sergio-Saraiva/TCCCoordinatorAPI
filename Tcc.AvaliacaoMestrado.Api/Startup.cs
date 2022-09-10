using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.OpenApi.Models;
using Serilog;
using Tcc.AvaliacaoMestrado.Application.Validators;
using Tcc.AvaliacaoMestrado.Ioc;
using Tcc.AvaliacaoMestrado.Shared.AppSettings;

namespace Tcc.AvaliacaoMestrado.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public AppSettings AppSettings { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).WriteTo.Console().WriteTo.Debug().CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //ConfigureAppSettings(services);

            services.AddOptions();

            services.AddHttpClient();

            services.AddHealthChecks();

            services.AddControllers();

            services.AddLogging((builder) => builder.AddSerilog(dispose: true));

            services.AddEntityFramework(Configuration);

            services.AddMediatR();

            services.AddCors();

            services.AddAutoMapperConfigureServices();

            services.AddApplicationDependecyInjection();

            services.AddMvc().AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<IValidatable>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Coordenador API", Version = "v1" });
            });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coordenador API V1"));
            }

            app.UseCors(p => p.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //private void ConfigureAppSettings(IServiceCollection services)
        //{
        //    services.Configure<AppSettings>(Configuration.GetSection(AppSettings.SectionName));
        //}
    }
}
