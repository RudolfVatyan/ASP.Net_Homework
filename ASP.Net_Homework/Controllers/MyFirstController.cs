using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASP.Net_Homework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExternalApiController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public ExternalApiController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("posts")]
    public IActionResult GetPosts([FromQuery] int userId, [FromQuery] string title)
    {
        var response = _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts?userId={userId}&title={title}")
                                  .GetAwaiter().GetResult();
        var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return Content(content, "application/json");
    }

    [HttpGet("posts/{id}")]
    public IActionResult GetPost(int id)
    {
        var response = _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}")
                                  .GetAwaiter().GetResult();
        var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return Content(content, "application/json");
    }

    [HttpPost("users")]
    public IActionResult CreateUser([FromBody] object userData)
    {
        var content = new StringContent(JsonSerializer.Serialize(userData), Encoding.UTF8, "application/json");
        var response = _httpClient.PostAsync("https://reqres.in/api/users", content)
                                  .GetAwaiter().GetResult();
        var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return Content(result, "application/json");
    }

    [HttpPut("users/{id}")]
    public IActionResult UpdateUser(int id, [FromBody] object userData)
    {
        var content = new StringContent(JsonSerializer.Serialize(userData), Encoding.UTF8, "application/json");
        var response = _httpClient.PutAsync($"https://reqres.in/api/users/{id}", content)
                                  .GetAwaiter().GetResult();
        var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return Content(result, "application/json");
    }

    [HttpDelete("posts/{id}")]
    public IActionResult DeletePost(int id)
    {
        var response = _httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{id}")
                                  .GetAwaiter().GetResult();
        return response.IsSuccessStatusCode ? NoContent() : StatusCode((int)response.StatusCode);
    }
}
