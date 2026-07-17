using Agriculture.Domain.Entites.Territory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Persistence.Configurations.Territory
{
    internal class GardenConfiguration : IEntityTypeConfiguration<Garden>
    {
        public void Configure(EntityTypeBuilder<Garden> builder)
        {
            builder.ToTable("Gardens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.HasMany(x => x.GardenPlots)
                .WithOne(x => x.Garden)
                .HasForeignKey(x => x.GardenId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
