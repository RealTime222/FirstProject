using entities;

namespace data_layer
{
    public interface IdataOrderItem
    {
        Task<OrderItem> AddOrder(OrderItem order);
    }
}