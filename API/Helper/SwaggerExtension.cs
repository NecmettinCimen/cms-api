using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace cms_api.Helper
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddJwtSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "cms_api", Version = "v1" });

                            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                            {
                                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                                Name = "Authorization",
                                In = ParameterLocation.Header,
                                Type = SecuritySchemeType.ApiKey,
                                Scheme = "Bearer"
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
                    Array.Empty<string>()
                }
                });
             });

            return services;
        }
    
    }
}