using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        //Foreign Key
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        //Foreign Key
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(80, ErrorMessage = "Title can't be longer than 80 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }
        public string Type { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        public string Condition { get; set; }
        public string InventoryStatus { get; set; }
    }
}
