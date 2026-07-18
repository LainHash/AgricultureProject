using Agriculture.Domain.Entites.Templates;
using Agriculture.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;

namespace Agriculture.Persistence.Seeders.Templates
{
    internal class GardenTemplateSeeder : IDataSeeder
    {
        private readonly IMapper _mapper;

        public GardenTemplateSeeder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task SeedAsync(AgricultureDbContext context)
        {
            var query = context.GardenTemplates;
            var sheetName = "GardenTemplates";

            if (await query.AnyAsync())
                return;

            var xlsxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "AgricultureData.xlsx");
            if (!File.Exists(xlsxPath))
                throw new FileNotFoundException($"Seed data file not found: {xlsxPath}");

            var records = MiniExcel.Query<GardenTemplateRecord>(xlsxPath, sheetName).ToList();

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var record in records)
                {
                    query.Add(_mapper.Map<GardenTemplate>(record));
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            });
        }

        public class GardenTemplateRecord
        {
            public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }

            public string UnlockType { get; set; } = string.Empty;
            public decimal UnlockValue { get; set; }
            public decimal UnlockPrice { get; set; }

            public int? ReferenceId { get; set; }
        }
    }
}
