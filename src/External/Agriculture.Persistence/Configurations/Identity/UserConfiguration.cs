using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Entites.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Persistence.Configurations.Identity
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.PublicId)
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Balance)
                .HasColumnType("decimal(12,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(x => x.Player)
                .WithOne(x => x.User)
                .HasForeignKey<Player>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
