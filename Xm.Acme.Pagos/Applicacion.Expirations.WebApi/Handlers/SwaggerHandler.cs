using Applicacion.Pagos.WebApi;
using Common.Utils.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Applicacion.Pagos.WebApi.Handlers
{
    public static class SwaggerHandler
    {
        public static void SwaggerConfig(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.IncludeXmlComments(Path.ChangeExtension(typeof(Startup).Assembly.Location, "xml"));
                options.SwaggerDoc(SwaggerConfiguration.DocInfoVersion, new Info
                {
                    Version = SwaggerConfiguration.DocInfoVersion,
                    Title = SwaggerConfiguration.DocInfoTitle,
                    Description = SwaggerConfiguration.DocInfoDescription
                });
                options.CustomSchemaIds(x => x.FullName);

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Array.Empty<string>() }
                };

                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                options.AddSecurityRequirement(security);

            });

        }


        public static void UseSwagger(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Administracion Deudas Web Api");
            });
        }
    }
}
