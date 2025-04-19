using Domain.Entities.OrderEntities;
using Shared.OrderModels;
using ShippingAddress = Domain.Entities.OrderEntities.Address;
namespace Services.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress, AddressDto>();
            
            CreateMap<DeliveryMethod, DeliveryMethodResult>();
            
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.Product.PictureUrl))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.ProductId));

            CreateMap<Order, OrderResult>()
                .ForMember(d => d.PaymentStatus, o => o.MapFrom(s => s.ToString()))
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.Total, o => o.MapFrom(s => s.SubTotal + s.DeliveryMethod.Price));
        }
    }
}
