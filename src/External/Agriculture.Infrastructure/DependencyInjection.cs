using Agriculture.Application.Services.Authentication;
using Agriculture.Application.Services.Emails;
using Agriculture.Application.Services.Storage;
using Agriculture.Contract.Settings.Authentication;
using Agriculture.Contract.Settings.Emails;
using Agriculture.Contract.Settings.Storage;
using Agriculture.Infrastructure.Services.Authentication;
using Agriculture.Infrastructure.Services.Emails;
using Agriculture.Infrastructure.Services.Storage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // ── Cloudinary ───────────────────────────────────────────────────
            services.Configure<CloudinarySettings>(
                configuration.GetSection(CloudinarySettings.SectionName));
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            // ── Authentication & Security ────────────────────────────────────
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IEmailService, EmailService>();

            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            if (jwtSettings is not null)
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                    options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                    {
                        OnAuthenticationFailed = ctx =>
                        {
                            Console.WriteLine($"[JWT] Auth failed: {ctx.Exception.GetType().Name}: {ctx.Exception.Message}");
                            return System.Threading.Tasks.Task.CompletedTask;
                        },
                        OnChallenge = ctx =>
                        {
                            Console.WriteLine($"[JWT] Challenge: error={ctx.Error}, desc={ctx.ErrorDescription}");
                            return System.Threading.Tasks.Task.CompletedTask;
                        },
                        OnMessageReceived = ctx =>
                        {
                            Console.WriteLine($"[JWT] Token received: {(string.IsNullOrEmpty(ctx.Token) ? "NONE" : ctx.Token[..Math.Min(30, ctx.Token.Length)] + "...")}");
                            return System.Threading.Tasks.Task.CompletedTask;
                        }
                    };
                });
            }

            return services;
        }
    }
}
