using System;

namespace BlogEngine.Common.Entities
{
    /// <summary>
    /// Class to break the circular relationship
    /// Classs Response Json messagges Rest API
    /// </summary>
    public class PostResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
