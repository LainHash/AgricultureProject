using Agriculture.Domain.Entites.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Persistence.Configurations.Catalog
{
    public class PlantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {

            builder.ToTable("Plants");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(x => x.PlantSpecicesId)
                .IsRequired();

            builder.Property(x => x.GardenPlotId)
                .IsRequired();

            builder.Property(x => x.PlantAt)
                .IsRequired();

            builder.Property(x => x.ExpectedHarvestAt)
                .IsRequired();

            builder.Property(x => x.Health)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(x => x.Moisture)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(x => x.Fertilizer)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(x => x.IsDead)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
