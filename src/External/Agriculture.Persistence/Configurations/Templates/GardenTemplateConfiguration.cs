using Agriculture.Domain.Entites.Templates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Persistence.Configurations.Templates
{
    internal class GardenTemplateConfiguration : IEntityTypeConfiguration<GardenTemplate>
    {
        public void Configure(EntityTypeBuilder<GardenTemplate> builder)
        {
            builder.ToTable("GardenTemplates");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.UnlockType)
                .IsRequired();

            builder.Property(x => x.UnlockValue)
                .IsRequired();

            builder.Property(x => x.UnlockPrice)
                .IsRequired();

            builder.HasMany(x => x.GardenPlotTemplates)
                .WithOne(x => x.GardenTemplate)
                .HasForeignKey(x => x.GardenTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
