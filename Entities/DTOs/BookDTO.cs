using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string AuthorId { get; set; }
        public string PublisherId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Condition { get; set; }
    }
}
