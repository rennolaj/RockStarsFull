using AutoMapper;
using RockStars.Api.Controllers.v1.Songs.Requests;
using RockStars.Application.Songs.Command.AddSong;

namespace RockStars.Api.AutoMapperProfiles.Songs
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<AddSongRequest, AddSongCommand>();
            CreateMap<DeleteSongRequest, DeleteSongCommand>();
        }
    }
}
