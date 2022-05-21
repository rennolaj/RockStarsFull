using MediatR;

namespace RockStars.Application.Artists.Command.AddArtist
{
    public class AddArtistCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
