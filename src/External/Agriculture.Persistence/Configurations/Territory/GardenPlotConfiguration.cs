using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Persistence.Configurations.Territory
{
    internal class GardenPlotConfiguration : IEntityTypeConfiguration<GardenPlot>
    {
        public void Configure(EntityTypeBuilder<GardenPlot> builder)
        {
            builder.ToTable("GardenPlots");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(x => x.Row)
                .IsRequired();

            builder.Property(x => x.Column)
                .IsRequired();

            builder.Property(x => x.SoilType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasDefaultValue(nameof(GardenPlotStatus.Empty))
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
