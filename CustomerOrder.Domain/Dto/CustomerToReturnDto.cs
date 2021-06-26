using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Domain.Dto
{
    public class CustomerToReturnDto
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public AddressToReturnDto Address { get; set; }
        public List<OrderToReturnDto> Orders { get; set; }
    }
}
