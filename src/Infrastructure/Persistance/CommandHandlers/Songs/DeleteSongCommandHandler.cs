using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RockStars.Application.Songs.Command.AddSong;
using RockStars.Common.Exceptions;
using RockStars.Domain.Entities.Songs;
using RockStars.Persistance.Db;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RockStars.Persistance.CommandHandlers.Songs
{
    public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand, int>
    {
        private readonly CleanArchWriteDbContext dbContext;
        private readonly ILogger<DeleteSongCommandHandler> logger;

        public DeleteSongCommandHandler(CleanArchWriteDbContext dbContext, ILogger<DeleteSongCommandHandler> logger)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
        {
            var existingSong = await dbContext.Set<Song>().FirstOrDefaultAsync(a => a.Id == request.Id);
            if (existingSong == null)
            {
                throw new NotFoundException("This Song does not exists");
            }

            dbContext.Set<Song>().Remove(existingSong);

            await dbContext.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Song deleted", existingSong);

            return existingSong.Id;
        }
    }
}
