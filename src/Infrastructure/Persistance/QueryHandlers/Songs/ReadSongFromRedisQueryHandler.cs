using MediatR;
using Microsoft.EntityFrameworkCore;
using PolyCache.Cache;
using RockStars.Application.Songs.Query.ReadSongFromRedis;
using RockStars.Domain.Entities.Songs;
using RockStars.Persistance.Db;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RockStars.Persistance.QueryHandlers.Products
{
    public class ReadSongFromRedisQueryHandler : IRequestHandler<ReadSongFromRedisQuery, ReadSongFromRedisResponse>
    {
        private readonly CleanArchReadOnlyDbContext dbContext;
        private readonly IStaticCacheManager staticCacheManager;
        private const string CachePrefix = "song_";
        private const int CacheExpiryTime = 2; //minitues

        public ReadSongFromRedisQueryHandler(CleanArchReadOnlyDbContext dbContext,
                                                IStaticCacheManager staticCacheManager)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.staticCacheManager = staticCacheManager ?? throw new ArgumentNullException(nameof(staticCacheManager));
        }

        public async Task<ReadSongFromRedisResponse> Handle(ReadSongFromRedisQuery request, CancellationToken cancellationToken)
        {
            var songId = request.SongId;

            var result = await staticCacheManager.GetWithExpireTimeAsync(
                new CacheKey(CachePrefix + songId),
                CacheExpiryTime,
                async () => await GetSongAsync());

            return result;

            async Task<ReadSongFromRedisResponse> GetSongAsync()
            {
                var Song = await dbContext.Set<Song>().Where(a => a.Id == songId).Select(a =>
                       new ReadSongFromRedisResponse
                       {
                           Name = a.Name,
                       }).FirstOrDefaultAsync();

                return Song;
            }
        }
    }
}
