using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrder.Domain.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
