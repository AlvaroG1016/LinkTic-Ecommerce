using Dropi_Dev.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dropi_Dev.JwtSetup
{
    public static class JwtAuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                            var response = ResponseBuilder.BuildErrorResponse("Token inválido o expirado.");
                            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse(); // Evita la respuesta por defecto
                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                            var response = ResponseBuilder.BuildErrorResponse("Acceso no autorizado. Proporcione un token válido.");
                            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
                        },
                        OnForbidden = context =>
                        {
                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;

                            var response = ResponseBuilder.BuildErrorResponse("No tiene permisos para acceder a este recurso.");
                            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
                        }
                    };
                });

            return services;
        }
    }
}
