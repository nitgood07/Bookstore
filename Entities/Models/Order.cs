using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
