using Agriculture.Domain.Entites.Templates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Persistence.Configurations.Templates
{
    internal class GardenPlotTemplateConfiguration : IEntityTypeConfiguration<GardenPlotTemplate>
    {
        public void Configure(EntityTypeBuilder<GardenPlotTemplate> builder)
        {
            builder.ToTable("GardenPlotTemplates");

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

            builder.HasIndex(x => new { x.GardenTemplateId, x.Row, x.Column })
                .IsUnique();
        }
    }
}
