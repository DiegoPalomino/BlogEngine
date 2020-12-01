using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Common.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Post
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50, ErrorMessage = "The field {0} must contain less than {1} characteres.")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(500, ErrorMessage = "The field {0} must contain less than {1} characteres.")]
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Pub Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "The Category selection is required")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
