using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.UserServices
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);

        Task<User> GetUserByEmail(string email);

        Task<User> UpdateUserAsync(User user);

        Task<User> GetUserById(Guid Id);



    }
}
