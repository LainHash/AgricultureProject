using Agriculture.Persistence.Contexts;

namespace Agriculture.Persistence.Seeders
{
    internal interface IDataSeeder
    {
        Task SeedAsync(AgricultureDbContext context);
    }
}
