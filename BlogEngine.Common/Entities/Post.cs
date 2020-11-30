using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [NotMapped]
        [Required]
        public int IdCategory { get; set; }
    }
}
