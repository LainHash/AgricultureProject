using Agriculture.Domain.Entites.Territory;
using Agriculture.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;

namespace Agriculture.Persistence.Seeders.Territory
{
    internal class GardenSeeder : IDataSeeder
    {
        private readonly IMapper _mapper;

        public GardenSeeder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task SeedAsync(AgricultureDbContext context)
        {
            var query = context.Gardens;
            var sheetName = "Gardens";

            if (await query.AnyAsync())
                return;

            var xlsxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "AgricultureData.xlsx");
            if (!File.Exists(xlsxPath))
                throw new FileNotFoundException($"Seed data file not found: {xlsxPath}");

            var records = MiniExcel.Query<GardenRecord>(xlsxPath, sheetName).ToList();

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var record in records)
                {
                    query.Add(_mapper.Map<Garden>(record));
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            });
        }

        public class GardenRecord
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }
        }
    }
}

