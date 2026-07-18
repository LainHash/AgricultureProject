using Agriculture.Domain.Entites.Catalog;
using Agriculture.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;

namespace Agriculture.Persistence.Seeders.Catalog
{
    internal class PlantSpecicesSeeder : IDataSeeder
    {
        private readonly IMapper _mapper;

        public PlantSpecicesSeeder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task SeedAsync(AgricultureDbContext context)
        {
            if (await context.PlantSpecices.AnyAsync())
                return;

            var xlsxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "AgricultureData.xlsx");

            if (!File.Exists(xlsxPath))
            {
                throw new FileNotFoundException($"Seed data file not found: {xlsxPath}");
            }

            var records = MiniExcel.Query<PlantSpecicesRecord>(xlsxPath, sheetName: "PlantSpecices").ToList();

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var record in records)
                {
                    context.PlantSpecices.Add(_mapper.Map<PlantSpecices>(record));
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            });
        }

        public class PlantSpecicesRecord
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int CategoryId { get; set; }
            public string ScientificName { get; set; } = string.Empty;
            public string? Description { get; set; }
            public decimal GrowDays { get; set; }
            public decimal HarvestDays { get; set; }
            public decimal WaterIntervalHours { get; set; }
            public decimal SunlightLevel { get; set; }
            public decimal TemperatureMin { get; set; }
            public decimal TemperatureMax { get; set; }
        }
    }
}
