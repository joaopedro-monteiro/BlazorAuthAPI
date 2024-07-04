using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuthAPI.Core.Shared.Jwt
{
    public static class JwtService
    {
        public static string GenerateToken(Dictionary<string, string> userInfo)
        {
            var securityKey = JwtOptions.GetSymmetricSecurityKey();
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = userInfo
                .Select(k => new Claim(k.Key, k.Value))
                .ToList();

            var expires = DateTime.Now.AddHours(8);
            var token = new JwtSecurityToken(JwtOptions.Issuer, JwtOptions.Audience, claims, expires: expires, signingCredentials: signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
