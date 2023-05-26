using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.UserServices
{
    public interface IUserService
    {
        void AddUser(User user);

        Task<User> GetUserByEmail(string email);

        void UpdateUser(User user);

        Task<User> GetUserById(Guid Id);



    }
}
