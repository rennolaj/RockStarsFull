using AutoMapper;
using RockStars.Api.Controllers.v1.Artists.Requests;
using RockStars.Application.Artists.Command.AddArtist;

namespace RockStars.Api.AutoMapperProfiles.Artists
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<AddArtistRequest, AddArtistCommand>();
        }
    }
}
