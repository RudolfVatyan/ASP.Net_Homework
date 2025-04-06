using Microsoft.AspNetCore.Mvc;
using ASP.Net_Homework.Models;
using ASP.Net_Homework.Repositories.Interfaces;

namespace ASP.Net_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts([FromQuery] int? userId, [FromQuery] string title)
        {
            var posts = await _postRepository.GetPosts(userId, title);
            if (posts == null || !posts.Any())
                return NotFound();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost([FromRoute] int id)
        {
            var post = await _postRepository.GetPost(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost([FromRoute] int id)
        {
            var post = await _postRepository.GetPost(id);
            if (post == null)
                return NotFound();

            var result = await _postRepository.DeletePost(id);
            if (result)
                return NoContent();

            return NotFound();
        }
    }
}


