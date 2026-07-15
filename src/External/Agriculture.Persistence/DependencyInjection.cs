using Agriculture.Application.Services.Catalog;
using Agriculture.Domain.Repositories;
using Agriculture.Persistence.Contexts;
using Agriculture.Persistence.Repositories;
using Agriculture.Persistence.Repositories.Catalog;
using Agriculture.Persistence.Services.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // ── Database ─────────────────────────────────────────────────────
            services.AddDbContext<AgricultureDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("MyConnectString"),
                    sqlOptions => sqlOptions.MigrationsAssembly(
                        typeof(AgricultureDbContext).Assembly.FullName)));


            // ── Repositories ─────────────────────────────────────────────────
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            var assembly = typeof(PlantSpecicesRepository).Assembly;

            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsClass || type.IsAbstract)
                    continue;

                if (!type.Name.EndsWith("Repository"))
                    continue;

                foreach (var iface in type.GetInterfaces())
                {
                    if (iface.Name.EndsWith("Repository"))
                    {
                        services.AddScoped(iface, type);
                    }
                }
            }

            // ── AutoMapper ───────────────────────────────────────────────────
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));

            // ── Services ─────────────────────────────────────────────────────
            services.AddScoped<IPlantSpecicesService, PlantSpecicesService>();

            return services;
        }

        public static async Task InitialiseDatabaseAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var sp = scope.ServiceProvider;

            var context = sp.GetRequiredService<AgricultureDbContext>();
            await context.Database.MigrateAsync();
        }
    }
}
