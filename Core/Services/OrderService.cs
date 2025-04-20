using Domain.Entities.OrderEntities;
using Shared.OrderModels;
using ShippingAddress = Domain.Entities.OrderEntities.Address;
namespace Services
{
    public class OrderService(IMapper mapper,IBasketRepository _basketRepository,IUnitOfWork _unitOfWork) : IOrderService
    {
        public async Task<OrderResult> CreateOrderAsync(OrderRequest orderRequest, string userEmail)
        {
            var shippingAddress = mapper.Map<ShippingAddress>(orderRequest.ShippingAddress);
            var basket = await _basketRepository.GetBasketAsync(orderRequest.BasketId) ??
                throw new BasketNotFoundException(orderRequest.BasketId);
            var orderItems = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(item.Id) ??
                    throw new ProductNotFoundException(item.Id);
                orderItems.Add(CreateOrderItem(item,product));
            }
            var deliveryMethod = await _unitOfWork.GetRepository<DeliveryMethod,int>()
                .GetByIdAsync(orderRequest.DeliveryMethodId) ?? throw new DeliveryMethodNotFoundException(orderRequest.DeliveryMethodId);
            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);
            var order = new Order(userEmail, shippingAddress, orderItems, deliveryMethod, subTotal);
            await _unitOfWork.GetRepository<Order, Guid>().AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return mapper.Map<OrderResult>(order);
        }

        private OrderItem CreateOrderItem(BasketItem item, Product product)
            => new OrderItem(new ProductInOrderItem(product.Id,product.Name,product.PictureUrl),item.Quantity,product.Price);
            
        
        public Task<IEnumerable<OrderResult>> GetAllOrdersByEmailAsync(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DeliveryMethodResult>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderResult> GetOrderByIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
