using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Service.Services;
using Domain.Service.Services.Interface;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTest.Domain.DependencyInjection
{
    public class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();


            var configuration = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .Build();

            services.AddSingleton(configuration);
                        
            //Domain
            services.AddScoped<IAgentCrossingsService, AgentCrossingsService>();


            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            //Contexto a db. Adicional se agrga configuración para permitir gurardado de varias peticiones al tiempo. 
            services.AddDbContext<Infraestructure.Core.Context.DBContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnectionStringSQLServer"),
               providerOptions => providerOptions.EnableRetryOnFailure()));

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
