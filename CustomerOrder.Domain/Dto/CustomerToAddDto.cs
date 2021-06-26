using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Domain.Dto
{
    public class CustomerToAddDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public AddressToAddDto Address { get; set; }
        public List<OrderToAddDto> Orders { get; set; }
    }
}
