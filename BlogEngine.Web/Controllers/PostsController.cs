using BlogEngine.Common.Entities;
using BlogEngine.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngine.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PostsController : Controller
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
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Title");
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                Category category = await _context.Categories.Include(c => c.Posts).FirstOrDefaultAsync(c => c.Id == post.IdCategory);

                if (category == null)
                {
                    return NotFound();
                }

                try
                {
                    category.Posts.Add(post);
                    _context.Add(post);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Categories");
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same title.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Title");
            return View(post);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Posts.FirstOrDefault(p => p.Id == post.Id) != null);
            post.IdCategory = category.Id;

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Title");
            return View(post);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Categories");
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same title.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Title");
            return View(post);
        }
    }
}
