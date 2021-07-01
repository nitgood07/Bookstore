using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class BookForCreationDTO
    {
        
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(80, ErrorMessage = "Title can't be longer than 80 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        
        [DefaultValue("New")]
        public string Condition { get; set; }
        
        [DefaultValue("IN")]
        public string InventoryStatus { get; set; }
    }
}
