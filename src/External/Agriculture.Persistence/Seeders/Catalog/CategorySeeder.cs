using Agriculture.Domain.Entites.Catalog;
using Agriculture.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;

namespace Agriculture.Persistence.Seeders.Catalog
{
    internal class CategorySeeder : IDataSeeder
    {
        private readonly IMapper _mapper;

        public CategorySeeder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task SeedAsync(AgricultureDbContext context)
        {
            var query = context.Categories;
            var sheetName = "Categories";

            if (await query.AnyAsync())
                return;

            var xlsxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "AgricultureData.xlsx");
            if (!File.Exists(xlsxPath)) 
                throw new FileNotFoundException($"Seed data file not found: {xlsxPath}");

            var records = MiniExcel.Query<CategoryRecord>(xlsxPath, sheetName).ToList();

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var record in records)
                {
                    query.Add(_mapper.Map<Category>(record));
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            });
        }

        public class CategoryRecord
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }
        }
    }
}
