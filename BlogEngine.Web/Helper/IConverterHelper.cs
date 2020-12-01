using BlogEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngine.Web.Helper
{
    public interface IConverterHelper
    {
        CategoryResponse ToCategoryResponse(Category category);

        List<CategoryResponse> ToCategoryResponse(List<Category> categories);
    }
}
