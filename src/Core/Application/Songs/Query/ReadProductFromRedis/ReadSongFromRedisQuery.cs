using MediatR;

namespace RockStars.Application.Songs.Query.ReadSongFromRedis
{
    public class ReadSongFromRedisQuery : IRequest<ReadSongFromRedisResponse>
    {
        public ReadSongFromRedisQuery(int songId)
        {
            SongId = songId;
        }

        public int SongId { get; private set; }
    }
}
