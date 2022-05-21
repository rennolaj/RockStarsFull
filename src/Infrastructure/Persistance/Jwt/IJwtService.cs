using RockStars.Domain.Entities.Users;
using System.Threading.Tasks;

namespace RockStars.Persistance.Jwt
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(User user);
    }
}
