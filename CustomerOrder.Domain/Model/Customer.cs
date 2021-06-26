using CustomerOrder.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerOrder.Domain.Model
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
