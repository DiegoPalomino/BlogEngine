using BlogEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
