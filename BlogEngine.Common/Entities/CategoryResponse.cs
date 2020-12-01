using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Common.Entities
{
    public class CategoryResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<PostResponse> Posts { get; set; }
    }
}
