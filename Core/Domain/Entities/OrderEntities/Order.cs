using ShippingAddress = Domain.Entities.OrderEntities.Address;
namespace Domain.Entities.OrderEntities
{
    public class Order : BaseEntity<Guid>
    {
        public string  UserEmail { get; set; }
        public ShippingAddress ShippingAddress { get; set; }     
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderPaymentStatus PaymentStatus { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public int? DeliveryMethodId { get; set; }
        public decimal SubTotal { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public string PaymentIntenId { get; set; } =string.Empty;
    }
}
