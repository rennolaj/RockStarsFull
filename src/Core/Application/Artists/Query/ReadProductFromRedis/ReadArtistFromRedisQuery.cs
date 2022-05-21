using MediatR;
using RockStars.Application.Products.Query.ReadProductFromRedis;

namespace RockStars.Application.Artists.Query.ReadArtistFromRedis
{
    public class ReadArtistFromRedisQuery : IRequest<ReadArtistFromRedisResponse>
    {
        public int ArtistId { get; private set; }

        public ReadArtistFromRedisQuery(int artistId)
        {
            ArtistId = artistId;
        }
    }
}
