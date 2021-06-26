using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerOrder.Domain.Model
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AddressId { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public int HouseNumber { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
