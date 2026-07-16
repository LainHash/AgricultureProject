using Agriculture.Application.Services;
using Agriculture.Application.Services.Catalog;
using Agriculture.Application.Services.Guest;
using Agriculture.Domain.Repositories;
using Agriculture.Persistence.Contexts;
using Agriculture.Persistence.Repositories;
using Agriculture.Persistence.Repositories.Catalog;
using Agriculture.Persistence.Seeders;
using Agriculture.Persistence.Services;
using Agriculture.Persistence.Services.Catalog;
using Agriculture.Persistence.Services.Guest;
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

            // ── Seeders ──────────────────────────────────────────────────────

            // Orchestrator seeder
            services.AddScoped<DataSeeder>();

            // Auto-register all IDataSeeder implementations
            var seederTypes = typeof(DependencyInjection).Assembly.GetTypes()
                .Where(t => typeof(IDataSeeder).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in seederTypes)
            {
                services.AddScoped(type);
            }

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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlantSpecicesService, PlantSpecicesService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPlayerService, PlayerService>();

            return services;
        }

        public static async Task InitialiseDatabaseAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var sp = scope.ServiceProvider;

            var context = sp.GetRequiredService<AgricultureDbContext>();
            await context.Database.MigrateAsync();

            var seeder = sp.GetRequiredService<DataSeeder>();
            await seeder.SeedAllAsync();
        }
    }
}
