using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Mapping
{
    public class CharacterMap : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.Property(character => character.Nickname).HasMaxLength(20);
            builder.Property(character => character.Classes).HasMaxLength(20);
            builder.HasIndex(character => character.Nickname).IsUnique();
            builder.HasOne(character => character.Player)
                .WithMany(character => character.Characters)
                .HasForeignKey(character => character.PlayerId);
        }
    }
}
