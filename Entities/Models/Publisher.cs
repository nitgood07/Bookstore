using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(80, ErrorMessage = "Publisher Name can't be longer than 80 characters")]
        public string PublisherName { get; set; }
        public string Country { get; set; }
    }
}
