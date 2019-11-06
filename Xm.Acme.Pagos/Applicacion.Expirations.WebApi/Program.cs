using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Applicacion;
using Applicacion.Pagos;
using Applicacion.Pagos.WebApi;
using Applicacion.Pagos.WebApi;
using Common.Utils.AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Applicacion.Pagos.WebApi
{
    public class Program
    {

        public static void Main(string[] args)
        {
            // Inicialize Automapper
            SettingAutomapper.CreateMaps();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
