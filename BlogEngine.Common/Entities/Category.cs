using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Common.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50,ErrorMessage = "The field {0} must contain less than {1} characteres.")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Post> Posts { get; set; }
    }
}
