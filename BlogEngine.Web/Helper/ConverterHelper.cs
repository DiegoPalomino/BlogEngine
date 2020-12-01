using BlogEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogEngine.Web.Helper
{
    /// <summary>
    /// Converter entities to break the circular relationship
    /// </summary>
    public class ConverterHelper : IConverterHelper
    {
        /// <summary>
        /// Validation Only blog posts with a publication date equal to or prior to the current date
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public CategoryResponse ToCategoryResponse(Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Title = category.Title,
                Posts = category.Posts?.Select(p => new PostResponse
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    PublicationDate = p.PublicationDate
                }).Where(po => po.PublicationDate <= DateTime.UtcNow.Date).ToList()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public List<CategoryResponse> ToCategoryResponse(List<Category> categories)
        {
            List<CategoryResponse> list = new List<CategoryResponse>();
            foreach (Category category in categories)
            {
                list.Add(ToCategoryResponse(category));
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public PostResponse ToPostResponse(Post post)
        {
            return new PostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                PublicationDate = post.PublicationDate
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        public List<PostResponse> ToPostResponse(List<Post> posts)
        {
            List<PostResponse> list = new List<PostResponse>();
            foreach (Post post in posts)
            {
                if(post.PublicationDate <= DateTime.UtcNow.Date)
                    list.Add(ToPostResponse(post));
            }

            return list;
        }
    }
}
