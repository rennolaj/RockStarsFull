using AutoMapper;
using RockStars.Api.Controllers.v1.Users.Requests;
using RockStars.Application.Users.Command.CreateUser;
using RockStars.Application.Users.Command.Login;

namespace RockStars.Api.AutoMapperProfiles.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SingUpRequest, CreateUserCommand>();

            CreateMap<LoginRequest, LoginCommand>();
        }
    }
}
