using MediatR;

namespace RockStars.Application.Artists.Query.GetArtistById
{
    public class GetArtistByIdQuery : IRequest<ArtistQueryModel>
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }
    }
}