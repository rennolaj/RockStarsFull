using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockStars.Domain.Entities.Artists;

namespace RockStars.Persistance.Configuration.Artists
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable(nameof(Artist));
            builder.HasKey(k => k.Id);
        }
    }
}