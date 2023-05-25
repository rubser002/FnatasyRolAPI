using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<User> GetUserByEmail(string email);
        Task<bool> IsValidUser(string email, string password);

    }
}
