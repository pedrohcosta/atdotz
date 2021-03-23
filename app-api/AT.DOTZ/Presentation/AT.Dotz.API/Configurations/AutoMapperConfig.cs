using AutoMapper;
using AT.Dotz.API.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AT.Dotz.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
