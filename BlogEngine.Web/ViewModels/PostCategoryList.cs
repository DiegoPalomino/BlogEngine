using BlogEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngine.Web.ViewModels
{
    public class PostCategoryList : Post
    {
        public ICollection<Category> Categories { get; set; }
    }
}
