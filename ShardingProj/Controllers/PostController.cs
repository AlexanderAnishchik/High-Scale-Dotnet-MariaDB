using Microsoft.AspNetCore.Mvc;
using ShardingProj.Entities;
using ShardingProj.Services;

namespace ShardingProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {

        private readonly DataAccess _dataAccess;

        public PostController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetLatestPosts(string category, int count)
        {
            return await _dataAccess.ReadLatestPosts(category, count);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            await _dataAccess.CreatePost(post);
            return NoContent();
        }

        [HttpGet("InitDatabase")]
        public void InitDatabase([FromQuery] int countUsers, [FromQuery] int countCategories)
        {
            _dataAccess.InitDatabase(countUsers, countCategories);
        }

    }
}