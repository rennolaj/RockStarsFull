using MediatR;
using Microsoft.EntityFrameworkCore;
using RockStars.Domain.Entities.Artists;
using RockStars.Application.Artists.Query.GetArtistById;
using RockStars.Persistance.Db;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RockStars.Persistance.QueryHandlers.Artists
{
    public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, ArtistQueryModel>
    {
        private readonly CleanArchReadOnlyDbContext dbContext;

        public GetArtistByIdQueryHandler(CleanArchReadOnlyDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<ArtistQueryModel> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            var existingArtist = await dbContext.Set<Artist>().Where(a => a.Id == request.ArtistId).Select(a =>
               new ArtistQueryModel
               {
                   Name = a.Name,
               }).FirstOrDefaultAsync();

            return existingArtist;
        }
    }
}