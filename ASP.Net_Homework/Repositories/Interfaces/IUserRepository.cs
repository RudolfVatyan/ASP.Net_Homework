using ASP.Net_Homework.Models;


namespace ASP.Net_Homework.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
    }
}


