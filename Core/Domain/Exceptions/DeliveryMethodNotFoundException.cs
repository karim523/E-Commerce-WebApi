namespace Domain.Exceptions
{
    public sealed class DeliveryMethodNotFoundException(int Id) : NotFoundException($"The delivery method with {Id} is not found")
    {
    }
}
