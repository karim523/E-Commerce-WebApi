namespace Domain.Entities.OrderEntities
{
    public class OrderItem : BaseEntity<Guid>
    {
        public OrderItem()
        {

        }
        public OrderItem(ProductInOrderItem product, int quantity, double price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public ProductInOrderItem Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
