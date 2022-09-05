using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sundown2._0.Data;
using Sundown2._0.Services;
using Coravel;
using System.Reflection;
using System.Net.Http.Headers;

namespace Sundown2._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            // Format til at tilføje en service
            // services.AddTransient<IServiceNavn, ServiceNavn>;
            services.AddTransient<ISpaceStationService, SpaceStationService>();
            services.AddTransient<ILandingForecastService, LandingForecastService>();
            services.AddHttpClient<ISpaceStationService, SpaceStationService>();
            //services.AddHttpClient<ILandingForecastService, LandingForecastService>();
            services.AddTransient<SaveEveryFiveMinutes>();
            services.AddScheduler();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddHttpClient<ILandingForecastService, LandingForecastService>("sundown", config =>
            {
                var productValue = new ProductInfoHeaderValue("Sundown", "2.0");
                var commentValue = new ProductInfoHeaderValue("(+https://localhost:44302/api/landingforecast)");

                config.DefaultRequestHeaders.UserAgent.Add(productValue);
                config.DefaultRequestHeaders.UserAgent.Add(commentValue);
            });





            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sundown2._0", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sundown2._0 v1"));
            }

            // Coravel Scheduler
            var provider = app.ApplicationServices;
            provider.UseScheduler(scheduler =>
            {
                scheduler.Schedule<SaveEveryFiveMinutes>()
                .EveryFiveMinutes();             
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
