using entities;

namespace logic_layer
{
    public interface IlogicOrderItem
    {
        Task<OrderItem> AddOrder(OrderItem order);
    }
}