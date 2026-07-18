using Agriculture.Domain.Entites.Templates;
using Agriculture.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;

namespace Agriculture.Persistence.Seeders.Templates
{
    internal class GardenPlotTemplateSeeder : IDataSeeder
    {
        private readonly IMapper _mapper;

        public GardenPlotTemplateSeeder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task SeedAsync(AgricultureDbContext context)
        {
            var query = context.GardenPlotTemplates;
            var sheetName = "GardenPlotTemplates";

            if (await query.AnyAsync())
                return;

            var xlsxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "AgricultureData.xlsx");
            if (!File.Exists(xlsxPath))
                throw new FileNotFoundException($"Seed data file not found: {xlsxPath}");

            var records = MiniExcel.Query<GardenPlotTemplateRecord>(xlsxPath, sheetName).ToList();

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var record in records)
                {
                    query.Add(_mapper.Map<GardenPlotTemplate>(record));
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            });
        }

        public class GardenPlotTemplateRecord
        {
            public int GardenTemplateId { get; set; }
            public int Row { get; set; }
            public int Column { get; set; }
            public string SoilType { get; set; } = string.Empty;
        }
    }
}
