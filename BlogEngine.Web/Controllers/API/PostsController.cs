using BlogEngine.Common.Entities;
using BlogEngine.Web.Data;
using BlogEngine.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        private readonly IConverterHelper _converterHelper;

        /// <summary>
        /// Constructor PostsController and injection by attribute
        /// </summary>
        /// <param name="context"></param>
        /// <param name="converterHelper"></param>
        public PostsController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        /// <summary>
        /// Rest Api GET to get the Posts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            List<Post> posts = await _context.Posts.ToListAsync();
            if (posts != null && posts.Count<Post>() > 0)
            {
                return Ok(_converterHelper.ToPostResponse(posts));
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

            return Ok(_converterHelper.ToPostResponse(post));
        }
    }
}