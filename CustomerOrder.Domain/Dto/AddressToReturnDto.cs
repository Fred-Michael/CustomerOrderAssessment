using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Domain.Dto
{
    public class AddressToReturnDto
    {
        public string AddressId { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public int HouseNumber { get; set; }
    }
}
