namespace RockStars.Application.Songs.Query.ReadSongFromRedis
{
    public class ReadSongFromRedisResponse
    {
        public string Name { get; set; }

        public uint? Year { get; set; }

        public string Song { get; set; }

        public string ShortName { get; set; }

        public uint? Bpm { get; set; }

        public uint Duration { get; set; }

        public string Genre { get; set; }

        public string? SpotifyId { get; set; }

        public string? Album { get; set; }
    }
}
