using ASP.Net_Homework.Models;

namespace ASP.Net_Homework.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts(int? userId, string title);
        Task<Post> GetPost(int id);
        Task<bool> DeletePost(int id);
    }
}

