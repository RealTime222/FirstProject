using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_layer
{
    public class dataOrder : IdataOrder
    {
        WebApiProjectContext _WebApiProjectContext;
        public dataOrder(WebApiProjectContext context)
        {
            _WebApiProjectContext = context;
        }
        public async Task<Order> AddOrder(Order order)
        {
            //a
           await _WebApiProjectContext.Orders.AddAsync(order);
           
            await _WebApiProjectContext.SaveChangesAsync();
            return order;
        }
    }
}

