namespace CustomerOrder.Domain.Dto
{
    public class OrderToReturnDto
    {
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public decimal Amount { get; set; }
    }
}
