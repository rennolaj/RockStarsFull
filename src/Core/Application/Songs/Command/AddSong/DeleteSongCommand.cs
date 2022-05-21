using MediatR;

namespace RockStars.Application.Songs.Command.AddSong
{
    public class DeleteSongCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
