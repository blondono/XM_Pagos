using Common.Utils.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.IntegrationOracle.WebApi.Handlers
{
    public static class JwtConfigurationHandler
    {
        public static void ConfigureJwtAuthentication(IServiceCollection services, IConfigurationSection jwtAppSettings)
        {
            JwtSetting appSettings = jwtAppSettings.Get<JwtSetting>();
            byte[] secretKey = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
               {
                   jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                       ValidIssuer = appSettings.Issuer,
                       ValidAudience = appSettings.Issuer,
                   };
               });
        }

    }
}
