using Agriculture.Domain.Entites.Territory;
using Agriculture.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;

namespace Agriculture.Persistence.Seeders.Territory
{
    internal class GardenPlotSeeder : IDataSeeder
    {
        private readonly IMapper _mapper;

        public GardenPlotSeeder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task SeedAsync(AgricultureDbContext context)
        {
            var query = context.GardenPlots;
            var sheetName = "GardenPlots";

            if (await query.AnyAsync())
                return;

            var xlsxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "AgricultureData.xlsx");
            if (!File.Exists(xlsxPath))
                throw new FileNotFoundException($"Seed data file not found: {xlsxPath}");

            var records = MiniExcel.Query<GardenPlotRecord>(xlsxPath, sheetName).ToList();

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var record in records)
                {
                    query.Add(_mapper.Map<GardenPlot>(record));
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            });
        }

        public class GardenPlotRecord
        {
            public int Id { get; set; }
            public int GardenId { get; set; }
            public int Row { get; set; }
            public int Column { get; set; }
            public string SoilType { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }
    }
}

