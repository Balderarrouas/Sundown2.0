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
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Sundown2._0.ExceptionHandling;
using FluentValidation;
using Sundown2._0.Validators;
using Sundown2._0.Utils;

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
            services.AddTransient<ISpaceStationService, SpaceStationService>();
            services.AddTransient<ILandingForecastService, LandingForecastService>();
            services.AddTransient<IUserService, UserService>();            
            services.AddHttpClient<ISpaceStationService, SpaceStationService>();
            services.AddTransient<IMissionReportService, MissionReportService>();
            services.AddTransient<IMissionImageService, MissionImageService>();
            services.AddTransient<SaveEveryFiveMinutes>();
            services.AddTransient<SpaceStationUtils>();
            services.AddValidatorsFromAssemblyContaining<MissionReportDTOValidator>();
            services.AddScheduler();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                   ClockSkew = TimeSpan.Zero
               };
           });


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

            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Media")),
                RequestPath = "/Media",               
            }); ;

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
