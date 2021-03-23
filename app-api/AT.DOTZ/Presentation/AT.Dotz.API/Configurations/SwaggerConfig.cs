using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AT.Dotz.API.Configurations
{
    public static class SwaggerConfig 
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerDefaultValues>();

                /*c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });*/
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            //app.UseMiddleware<SwaggerAuthorizedMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My DN");
                });
            return app;
        }
    }
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {

        }

        static OpenApiInfo CreateInfoForApiVersion()
        {
            var info = new OpenApiInfo()
            {
                Title = "API",
                Version = "1.0",
                Description = "PI",
                Contact = new OpenApiContact() { Name = "Pedro", Email = "pedrohenriquecruzcosta@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            };

            return info;
        }
    }

    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            foreach (var parameter in operation.Parameters)
            {
                var description = context.ApiDescription
                    .ParameterDescriptions
                    .First(p => p.Name == parameter.Name);

                var routeInfo = description.RouteInfo;

                operation.Deprecated = OpenApiOperation.DeprecatedDefault;

                if (parameter.Description == null)
                {
                    parameter.Description = description.ModelMetadata?.Description;
                }

                if (routeInfo == null)
                {
                    continue;
                }

                if (parameter.In != ParameterLocation.Path && parameter.Schema.Default == null)
                {
                    parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());
                }

                parameter.Required |= !routeInfo.IsOptional;
            }
        }
    }

    public class SwaggerAuthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerAuthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger")
                && !context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next.Invoke(context);
        }
    }
}
