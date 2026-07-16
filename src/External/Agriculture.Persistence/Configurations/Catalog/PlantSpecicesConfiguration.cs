using Agriculture.Domain.Entites.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Persistence.Configurations.Catalog
{
    internal class PlantSpecicesConfiguration : IEntityTypeConfiguration<PlantSpecices>
    {
        public void Configure(EntityTypeBuilder<PlantSpecices> builder)
        {
            builder.ToTable("PlantSpecices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ScientificName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.GrowDays)
                .IsRequired()
                .HasColumnType("decimal(9,4)");

            builder.Property(x => x.HarvestDays)
                .IsRequired()
                .HasColumnType("decimal(9,4)");

            builder.Property(x => x.WaterIntervalHours)
                .IsRequired()
               .HasColumnType("decimal(8,4)");

            //Đơn vị riêng 0 - 1000
            builder.Property(x => x.SunlightLevel)
                .IsRequired()
                .HasColumnType("decimal(6,2)");

            //Đơn vị độ C
            builder.Property(x => x.TemperatureMin)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(x => x.TemperatureMax)
                .IsRequired()
                .HasColumnType("decimal(5,2)");
        }
    }
}
