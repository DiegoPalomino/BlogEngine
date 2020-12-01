using BlogEngine.Common.Entities;
using System.Collections.Generic;

namespace BlogEngine.Web.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConverterHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        CategoryResponse ToCategoryResponse(Category category);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        List<CategoryResponse> ToCategoryResponse(List<Category> categories);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        PostResponse ToPostResponse(Post post);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        List<PostResponse> ToPostResponse(List<Post> posts);
    }
}
