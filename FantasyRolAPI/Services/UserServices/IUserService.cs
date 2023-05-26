using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.UserServices
{
    public interface IUserService
    {
        void AddUser(User user);
        bool IsValidUser(string email, string password);

        Task<User> GetUserByEmail(string email);

        void UpdateUser(User user);

        Task<User> GetUserById(Guid Id);

        string HashPassword(string password);

    }
}
