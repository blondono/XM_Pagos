using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;

namespace Common.Utils.Utils.Interface
{
    public class HeaderClaims : IHeaderClaims
    {
        /// <summary>
        /// Method to get value claim from JwtToken
        /// </summary>
        /// <param name="authorization"> Request.Headers["Authorization"] </param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public string GetClaimValue(string authorization, string claim)
        {
            var handler = new JwtSecurityTokenHandler();

            string authHeader = authorization.Replace("Bearer ", "").Replace("bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            Claim claimData = tokenS.Claims.FirstOrDefault(cl => cl.Type.ToUpper() == claim.ToUpper());

            return claimData != null ? claimData.Value : string.Empty;
        }

        /// <summary>
        /// Method to get User Name from JwtToken
        /// </summary>
        /// <param name="authorization"> Request.Headers["Authorization"] </param>
        /// <returns></returns>
        public string GetUserNameAuth(string authorization)
        {
            var handler = new JwtSecurityTokenHandler();

            string authHeader = authorization.Replace("Bearer ", "").Replace("bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            //Claim claimData = tokenS.Claims.FirstOrDefault(cl => cl.Type.ToUpper() == "IdUsuario");

            var claimData = tokenS.Claims.FirstOrDefault(cl => cl.Type == "IdUsuario").Value;
            return claimData;
           // return claimData != null ? claimData.Value : string.Empty;
        }
    }
}
