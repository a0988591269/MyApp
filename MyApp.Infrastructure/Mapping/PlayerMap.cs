using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Mapping
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(player => player.Account).HasMaxLength(50);
            builder.Property(player => player.AccountType).HasMaxLength(10);
            builder.HasIndex(player => player.Account).IsUnique();
        }
    }
}
