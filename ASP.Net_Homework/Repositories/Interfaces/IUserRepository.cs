using ASP.Net_Homework.Models;


namespace ASP.Net_Homework.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserResponse> GetUser(int userId);
        Task<UserListResponse> GetUsers();
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
    }
}


