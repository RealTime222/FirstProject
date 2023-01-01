using entities;

namespace logic_layer
{
    public interface IlogicOrder
    {
        Task<Order> AddOrder(Order order);
    }
}