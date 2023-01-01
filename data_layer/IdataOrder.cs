using entities;

namespace data_layer
{
    public interface IdataOrder
    {
        Task<Order> AddOrder(Order order);
    }
}