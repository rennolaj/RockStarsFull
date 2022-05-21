using MediatR;
using Microsoft.EntityFrameworkCore;
using RockStars.Domain.Entities.Songs;
using RockStars.Application.Songs.Query.GetSongById;
using RockStars.Persistance.Db;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RockStars.Persistance.QueryHandlers.Songs
{
    public class GetSongByIdQueryHandler : IRequestHandler<GetSongByIdQuery, SongQueryModel>
    {
        private readonly CleanArchReadOnlyDbContext dbContext;

        public GetSongByIdQueryHandler(CleanArchReadOnlyDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<SongQueryModel> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            var existingSong = await dbContext.Set<Song>().Where(a => a.Id == request.SongId).Select(a =>
               new SongQueryModel
               {
                   Name = a.Name,
                   Year = a.Year,
                   Genre = a.Genre,
                   Artist = a.Artist,
                   Bpm = a.Bpm,
                   Duration = a.Duration,
                   SpotifyId = a.SpotifyId,
                   Album = a.Album,
                   ShortName = a.ShortName
               }).FirstOrDefaultAsync();

            return existingSong;
        }
    }
}