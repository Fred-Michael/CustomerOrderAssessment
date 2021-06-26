namespace CustomerOrder.Domain.Dto
{
    public class OrderToUpdateDto
    {
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public decimal Amount { get; set; }
    }
}