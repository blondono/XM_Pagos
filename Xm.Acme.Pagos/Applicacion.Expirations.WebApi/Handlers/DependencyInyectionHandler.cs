using Common.Utils.Utils.Interface;
using Domain.Service.Services;
using Domain.Service.Services.Interface;
using Domain.Service.Services.Strategy;
using Domain.Service.Services.Strategy.Behaviors;
using Infraestructure.Core.Context;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.RestServices;
using Infraestructure.Core.RestServices.Interface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applicacion.Pagos.WebApi.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            #region Register (dependency injection)

            // Repository await UnitofWork parameter ctor explicit
            services.AddScoped<UnitOfWork, UnitOfWork>();


            // Infrastructure
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<IOracleRepository, OracleRepository>();

            // Domain
            services.AddTransient<IFtpFileService, FtpFileService>();


            // Common
            services.AddTransient<IHeaderClaims, HeaderClaims>();
            services.AddTransient<IRestService, RestService>();

            #endregion
        }
    }
}
