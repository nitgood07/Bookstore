using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Address Line1 is required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        public string Zip { get; set; }
    }
}
