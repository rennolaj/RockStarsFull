using MediatR;
using Microsoft.EntityFrameworkCore;
using PolyCache.Cache;
using RockStars.Application.Artists.Query.ReadArtistFromRedis;
using RockStars.Domain.Entities.Products;
using RockStars.Persistance.Db;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RockStars.Persistance.QueryHandlers.Products
{
    public class ReadArtistFromRedisQueryHandler : IRequestHandler<ReadArtistFromRedisQuery, ReadArtistFromRedisResponse>
    {
        private readonly CleanArchReadOnlyDbContext dbContext;
        private readonly IStaticCacheManager staticCacheManager;
        private const string CachePrefix = "artist_";
        private const int CacheExpiryTime = 2; //minitues

        public ReadArtistFromRedisQueryHandler(CleanArchReadOnlyDbContext dbContext,
                                                IStaticCacheManager staticCacheManager)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.staticCacheManager = staticCacheManager ?? throw new ArgumentNullException(nameof(staticCacheManager));
        }

        public async Task<ReadArtistFromRedisResponse> Handle(ReadArtistFromRedisQuery request, CancellationToken cancellationToken)
        {
            var artistId = request.ArtistId;

            var result = await staticCacheManager.GetWithExpireTimeAsync(
                new CacheKey(CachePrefix + artistId),
                CacheExpiryTime,
                async () => await GetProductAsync());

            return result;

            async Task<ReadArtistFromRedisResponse> GetProductAsync()
            {
                var product = await dbContext.Set<Product>().Where(a => a.Id == artistId).Select(a =>
                       new ReadArtistFromRedisResponse
                       {
                           Name = a.Name,
                       }).FirstOrDefaultAsync();

                return product;
            }
        }
    }
}
