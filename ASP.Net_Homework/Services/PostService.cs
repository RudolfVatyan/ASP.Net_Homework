using Microsoft.Extensions.Options;
using ASP.Net_Homework.Models;
using ASP.Net_Homework.Repositories.Interfaces;
using System.Net.Http;

namespace ASP.Net_Homework.Repositories.Services
{
    public class PostService : IPostRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string? _baseUrl;

        public PostService(HttpClient httpClient, IOptions<PostsApiSettings> options)
        {
            _httpClient = httpClient;
            _baseUrl = options.Value.BaseUrl;
        }

        public async Task<IEnumerable<Post>> GetPosts(int? userId, string title)
        {
            var url = $"{_baseUrl}/posts";
            if (userId.HasValue || !string.IsNullOrEmpty(title))
            {
                url += "?";
                if (userId.HasValue)
                    url += $"userId={userId.Value}&";
                if (!string.IsNullOrEmpty(title))
                    url += $"title={Uri.EscapeDataString(title)}";
            }

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var posts = await response.Content.ReadFromJsonAsync<IEnumerable<Post>>();
                return posts ?? Enumerable.Empty<Post>(); 
            }

            return null;
        }

        public async Task<Post> GetPost(int id)
        {
            var url = $"{_baseUrl}/posts/{id}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Post>();
            }

            return null;
        }

        public async Task<bool> DeletePost(int id)
        {
            var url = $"{_baseUrl}/posts/{id}";
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}



