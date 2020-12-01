using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Common.Entities
{
    public class PostResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
