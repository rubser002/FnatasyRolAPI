using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<bool> Register(User user);
        Task<bool> Login(User user);
        bool IsTokenValid(string token);
        string GenerateToken(string email);
    }
}
