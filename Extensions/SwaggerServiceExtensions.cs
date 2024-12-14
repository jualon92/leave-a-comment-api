using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace leave_a_comment_api.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string apiKeyHeaderName)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = $"API Key needed to access the endpoints. ApiKey: {apiKeyHeaderName}",
                    In = ParameterLocation.Header,
                    Name = apiKeyHeaderName,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKeyScheme"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            },
                            Scheme = "ApiKeyScheme",
                            Name = apiKeyHeaderName,
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
