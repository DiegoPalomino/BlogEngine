using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogEngine.Common.Entities;
using BlogEngine.Web.Data;
using BlogEngine.Web.Helper;

namespace BlogEngine.Web.Controllers.API
{
    /// <summary>
    /// Rest API operations for Category entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="converterHelper"></param>
        public CategoriesController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<Category> categories = await _context.Categories.Include(c => c.Posts).ToListAsync();
            return Ok(_converterHelper.ToCategoryResponse(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Categories.FindAsync(id);
            category.Posts = new List<Post>();

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetCategoriesPosts(int id)
        {
            var categoryPosts = await _context.Categories.Include(c => c.Posts).FirstOrDefaultAsync(ca => ca.Id == id);

            if (categoryPosts != null && categoryPosts.Posts != null && categoryPosts.Posts.Count<Post>() > 0)
            {
                return Ok(_converterHelper.ToCategoryResponse(categoryPosts));
            }
            else
            {
                return NoContent();
            }
        }
    }
}