using Agriculture.Persistence.Contexts;
using Agriculture.Persistence.Seeders.Catalog;
using Agriculture.Persistence.Seeders.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Persistence.Seeders
{
    internal class DataSeeder
    {
        private readonly AgricultureDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public DataSeeder(IServiceProvider serviceProvider, AgricultureDbContext context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }

        public async Task SeedAllAsync()
        {
            await SeedAsync<PlantSpecicesSeeder>(_context);
            await SeedAsync<CategorySeeder>(_context);
            await SeedAsync<GardenTemplateSeeder>(_context);
            await SeedAsync<GardenPlotTemplateSeeder>(_context);
        }

        private async Task SeedAsync<TSeeder>(AgricultureDbContext context) where TSeeder : IDataSeeder
        {
            using var scope = _serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<TSeeder>();
            await seeder.SeedAsync(context);
        }
    }
}
