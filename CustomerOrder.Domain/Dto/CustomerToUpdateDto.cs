using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Domain.Dto
{
    public class CustomerToUpdateDto
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public AddressToUpdateDto Address { get; set; }
        public List<OrderToUpdateDto> Orders { get; set; } 
    }
}
