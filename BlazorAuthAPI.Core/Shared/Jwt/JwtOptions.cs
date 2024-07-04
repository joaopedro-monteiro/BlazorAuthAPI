using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuthAPI.Core.Shared.Jwt
{
    public static class JwtOptions
    {
        private const string Key = "pnlnq4b0xyoesccm9pz5mj9wlw2388qz73mxbrrho50e9uxpi757lpez3t53s1b2yuajd8hqygpin9hq6sdc3ggpfb08xehpetxfvjucoqxhkq1xjon15lrgy8fa5zcu";

        public const string Issuer = "Duett";
        public const string Audience = "Duett";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
