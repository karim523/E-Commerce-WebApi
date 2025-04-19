namespace Domain.Entities.OrderEntities
{
    public class OrderItem : BaseEntity<Guid>
    {
        public ProductInOrderItem Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
