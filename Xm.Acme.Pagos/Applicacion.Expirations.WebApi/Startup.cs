using Applicacion;
using Applicacion.IntegrationOracle;
using Applicacion.IntegrationOracle.WebApi;
using Applicacion.IntegrationOracle.WebApi.Areas.Job;
using Applicacion.IntegrationOracle.WebApi.Areas.Job.Models;
using Applicacion.IntegrationOracle.WebApi.Handlers;
using Applicacion.IntegrationOracle.WebApi;
using AutoMapper;
using Common.Utils.JWT;
using Common.Utils.Swagger;
using Common.Utils.Utils.Interface;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.RestServices;
using Infraestructure.Core.RestServices.Interface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Applicacion.IntegrationOracle.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
           .AddEnvironmentVariables();

            var e = env.EnvironmentName;

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            IConfigurationSection jwtAppSettings = Configuration.GetSection("Jwt");
            services.Configure<JwtSetting>(jwtAppSettings);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    p => p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddDistributedMemoryCache();
            services.AddSession();

            #region Swagger Configuration

            SwaggerHandler.SwaggerConfig(services);

            #endregion

            #region Jwt Configuration

            JwtConfigurationHandler.ConfigureJwtAuthentication(services, jwtAppSettings);

            #endregion

            #region Context

            #region Oracle

            services.AddDbContext<Infraestructure.Core.Context.Context>(options =>
               options.UseOracle(Configuration.GetConnectionString("ConnectionStringOracle")));

            #endregion

            //#region SQL

            //services.AddEntityFrameworkSqlServer()
            //   .AddDbContext<Infraestructure.Core.Context.Context>(options =>
            //   {
            //       options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringSQLServer"),
            //           sqlOptions => sqlOptions.MigrationsAssembly(typeof(Startup)
            //           .GetTypeInfo()
            //           .Assembly.GetName().Name));
            //   },
            //   ServiceLifetime.Scoped);
            //#endregion


            #endregion

            #region Register (dependency injection)

            DependencyInyectionHandler.DependencyInyectionConfig(services);

            #endregion

            ////#region Job 

            ////// Add Quartz services singleton
            //services.AddSingleton<IJobFactory, JobFactory>();
            //services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            //// Add our job
            //// services.AddSingleton<Job>();

            //services.AddSingleton<Job>();
            //services.AddSingleton(new JobScheduleModel(
            //    jobType: typeof(Job),
            //    cronExpression: "0/20 * * * * ?")); // run every 5 seconds
            //                                        // 0/10 * * * * ? * run every 10 seconds

            //// Configure job actions
            //services.AddHostedService<HostedService>();

            ////#endregion

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            var cultureInfo = new CultureInfo("es-CO");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseSession();
            SwaggerHandler.UseSwagger(app);
            app.UseDeveloperExceptionPage();
            app.UseMvc();


            appLifetime.ApplicationStarted.Register(() =>
            {

            });

            appLifetime.ApplicationStopped.Register(() =>
            {

            });
        }
    }
}
