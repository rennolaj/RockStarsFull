using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockStars.Domain.Entities.Songs;

namespace RockStars.Persistance.Configuration.Songs
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable(nameof(Song));
            builder.HasKey(k => k.Id);
        }
    }
}