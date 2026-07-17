using Agriculture.Domain.Entites.Guest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Persistence.Configurations.Guest
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(x => x.Nickname)
                .HasDefaultValue("Gardener")
                .IsRequired();

            builder.Property(x => x.Level)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.Experience)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.Gold)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.Gem)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.Energy)
                .HasDefaultValue(360)
                .IsRequired();

            builder.Property(x => x.LastLoginAt)
                .IsRequired();
        }
    }
}
