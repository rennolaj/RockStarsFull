using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RockStars.Application.Songs.Command.AddSong;
using RockStars.Common.Exceptions;
using RockStars.Domain.Entities.Artists;
using RockStars.Domain.Entities.Songs;
using RockStars.Persistance.Db;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RockStars.Persistance.CommandHandlers.Songs
{
    public class AddSongCommandHandler : IRequestHandler<AddSongCommand, int>
    {
        private readonly CleanArchWriteDbContext dbContext;
        private readonly ILogger<AddSongCommandHandler> logger;

        public AddSongCommandHandler(CleanArchWriteDbContext dbContext, ILogger<AddSongCommandHandler> logger)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddSongCommand request, CancellationToken cancellationToken)
        {
            var existingSong = await dbContext.Set<Song>().FirstOrDefaultAsync(a => a.Name == request.Name);
            if (existingSong != null)
            {
                throw new ExistingRecordException("This Song has been added");
            }

            var existingArtist = await dbContext.Set<Artist>().FirstOrDefaultAsync(a => a.Name == request.Artist);
            if (existingArtist == null)
            {
                var artist = new Artist
                {
                    Name = request.Artist
                };
                await dbContext.Set<Artist>().AddAsync(artist, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                existingArtist = await dbContext.Set<Artist>().FirstOrDefaultAsync(a => a.Name == request.Artist);
            }

            var song = new Song
            {
                Name = request.Name,
                Year = request.Year,
                Genre = request.Genre,
                ArtistId = existingArtist.Id,
                Artist = request.Artist,
                Bpm = request.Bpm,
                Duration = request.Duration,
                SpotifyId = request.SpotifyId,
                Album = request.Album,
                ShortName = request.ShortName

            };

            await dbContext.Set<Song>().AddAsync(song, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Song Inserted", song);

            return song.Id;
        }
    }
}
