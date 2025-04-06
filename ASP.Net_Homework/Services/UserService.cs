using Microsoft.Extensions.Options;
using ASP.Net_Homework.Models;
using ASP.Net_Homework.Repositories.Interfaces;

using System.Net.Http;

namespace ASP.Net_Homework.Repositories.Services
{
    public class UserService : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string? _baseUrl;

        public UserService(HttpClient httpClient, IOptions<UsersApiSettings> options)
        {
            _httpClient = httpClient;
            _baseUrl = options.Value.BaseUrl;
        }

        public async Task<User> CreateUser(User user)
        {
            var url = $"{_baseUrl}/api/users";
            var response = await _httpClient.PostAsJsonAsync(url, user);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }

        public async Task<UserResponse> GetUser(int userId)
        {
            var url = $"{_baseUrl}/api/users/{userId}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var userResponse = await response.Content.ReadFromJsonAsync<UserResponse>();
                return userResponse;
            }
            return null;
        }

        public async Task<UserListResponse> GetUsers()
        {
            var url = $"{_baseUrl}/api/users";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var userListResponse = await response.Content.ReadFromJsonAsync<UserListResponse>();
                return userListResponse;
            }
            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
            var url = $"{_baseUrl}/api/users/{user.Id}";
            var response = await _httpClient.PutAsJsonAsync(url, user);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }
    }
}


