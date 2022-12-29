using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_layer
{
    public class dataOrderItem : IdataOrderItem
    {
        WebApiProjectContext _WebApiProjectContext;
        public dataOrderItem(WebApiProjectContext context)
        {
            _WebApiProjectContext = context;
        }
        public async Task<OrderItem> AddOrder(OrderItem order)
        {
            await _WebApiProjectContext.OrderItems.AddAsync(order);
            await _WebApiProjectContext.SaveChangesAsync();
            return order;
        }
    }
}

