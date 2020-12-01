using BlogEngine.Common.Entities;
using BlogEngine.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace BlogEngine.Web.Controllers.API
{
    /// <summary>
    /// Rest API operations for Post entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public PostsController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _context.Posts;

            if (posts != null && posts.Count<Post>() > 0)
            {
                return Ok(_context.Posts.Where(p => p.PublicationDate <= DateTime.UtcNow.Date).ToList());
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}