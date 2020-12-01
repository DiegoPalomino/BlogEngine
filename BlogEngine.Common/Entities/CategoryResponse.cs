using System.Collections.Generic;

namespace BlogEngine.Common.Entities
{
    /// <summary>
    /// Class to break the circular relationship
    /// Classs Response Json messagges Rest API
    /// </summary>
    public class CategoryResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<PostResponse> Posts { get; set; }
    }
}
