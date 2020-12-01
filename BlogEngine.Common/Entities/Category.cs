using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Common.Entities
{
    /// <summary>
    /// Category Entity for Data Model 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title attribute
        /// </summary>
        [MaxLength(50, ErrorMessage = "The field {0} must contain less than {1} characteres.")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Relationship one to many
        /// </summary>
        public ICollection<Post> Posts { get; set; }
    }
}
