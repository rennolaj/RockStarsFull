using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RockStars.Domain.Entities.Artists;
using RockStars.Application.Artists.Command.AddArtist;
using RockStars.Common.Exceptions;
using RockStars.Persistance.Db;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RockStars.Persistance.CommandHandlers.Artists
{
    public class AddArtistCommandHandler : IRequestHandler<AddArtistCommand, int>
    {
        private readonly CleanArchWriteDbContext dbContext;
        private readonly ILogger<AddArtistCommandHandler> logger;

        public AddArtistCommandHandler(CleanArchWriteDbContext dbContext, ILogger<AddArtistCommandHandler> logger)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            var existingArtist = await dbContext.Set<Artist>().FirstOrDefaultAsync(a => a.Name == request.Name);

            if (existingArtist != null)
            {
                throw new ExistingRecordException("This Artist has been added");
            }

            var artist = new Artist
            {
                Name = request.Name,
            };

            await dbContext.Set<Artist>().AddAsync(artist, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Artist Inserted", artist);

            return artist.Id;
        }
    }
}
