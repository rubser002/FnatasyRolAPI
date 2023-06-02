using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<User> Register(User user);
        Task<User> Login(User user);
        bool IsTokenValid(string token);
        string GenerateToken(string email);
    }
}
