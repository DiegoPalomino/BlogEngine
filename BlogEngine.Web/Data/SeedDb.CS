using BlogEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngine.Web.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class SeedDb
    {
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category
                {
                    Title = "Category Test 0",
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            Title = "Post Test 0 - Category Test 0",
                            Content = "Post Test 0 Post Test 0 Post Test 0",
                            PublicationDate = DateTime.UtcNow.AddDays(-2)
                        },
                        new Post
                        {
                            Title = "Post Test 1 - Category Test 0",
                            Content = "Post Test 1 Post Test 1 Post Test 1",
                            PublicationDate = DateTime.UtcNow.AddDays(-1)
                        },
                        new Post
                        {
                            Title = "Post Test 2 - Category Test 0",
                            Content = "Post Test 2 Post Test 2 Post Test 2",
                            PublicationDate = DateTime.UtcNow
                        },
                        new Post
                        {
                            Title = "Post Test 3 - Category Test 0",
                            Content = "Post Test 3 Post Test 3 Post Test 3",
                            PublicationDate = DateTime.UtcNow.AddDays(1)
                        }
                    }
                });

                _context.Categories.Add(new Category
                {
                    Title = "Category Test 1",
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            Title = "Post Test 0 - Category Test 1",
                            Content = "Post Test 0 Post Test 0 Post Test 0",
                            PublicationDate = DateTime.UtcNow.AddDays(-2)
                        },
                        new Post
                        {
                            Title = "Post Test 1 - Category Test 1",
                            Content = "Post Test 1 Post Test 1 Post Test 1",
                            PublicationDate = DateTime.UtcNow.AddDays(-1)
                        },
                        new Post
                        {
                            Title = "Post Test 2 - Category Test 1",
                            Content = "Post Test 2 Post Test 2 Post Test 2",
                            PublicationDate = DateTime.UtcNow
                        },
                        new Post
                        {
                            Title = "Post Test 3 - Category Test 1",
                            Content = "Post Test 3 Post Test 3 Post Test 3",
                            PublicationDate = DateTime.UtcNow.AddDays(1)
                        }
                    }
                });

                _context.Categories.Add(new Category
                {
                    Title = "Category Test 2",
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            Title = "Post Test 0 - Category Test 2",
                            Content = "Post Test 0 Post Test 0 Post Test 0",
                            PublicationDate = DateTime.UtcNow.AddDays(-2)
                        },
                        new Post
                        {
                            Title = "Post Test 1 - Category Test 2",
                            Content = "Post Test 1 Post Test 1 Post Test 1",
                            PublicationDate = DateTime.UtcNow.AddDays(-1)
                        },
                        new Post
                        {
                            Title = "Post Test 2 - Category Test 2",
                            Content = "Post Test 2 Post Test 2 Post Test 2",
                            PublicationDate = DateTime.UtcNow
                        },
                        new Post
                        {
                            Title = "Post Test 3 - Category Test 2",
                            Content = "Post Test 3 Post Test 3 Post Test 3",
                            PublicationDate = DateTime.UtcNow.AddDays(1)
                        }
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}