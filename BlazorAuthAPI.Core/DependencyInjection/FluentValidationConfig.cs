using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAuthAPI.Core.DependencyInjection
{
    public static class FluentValidationConfig
    {
        public static void RegisterFluentValidation(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddValidatorsFromAssemblies(assemblies);
        }
    }
}
