using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Entites.Territory;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Agriculture.Persistence.Contexts
{
    internal class AgricultureDbContext : DbContext
    {
        public AgricultureDbContext(DbContextOptions<AgricultureDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<PlantSpecices> PlantSpecices { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;

        public DbSet<Garden> Gardens { get; set; } = null!;
        public DbSet<GardenPlot> GardenPlots { get; set; } = null!;

        public DbSet<GardenTemplate> GardenTemplates { get; set; } = null!;
        public DbSet<GardenPlotTemplate> GardenPlotTemplates { get; set; } = null!;

        // ── Model building ──────────────────────────────────────────────────
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Auto-register all IEntityTypeConfiguration<T> classes in this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // ── Auto-set audit fields on SaveChanges ────────────────────────────
        public override int SaveChanges()
        {
            SetAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditFields()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<Domain.Abstraction.AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.MarkCreated(now);
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.MarkUpdated(now);
                }
            }
        }
    }
}
