using data_layer;
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class logicOrderItem : IlogicOrderItem
    {
        private readonly IdataOrderItem _Idata;
        public logicOrderItem(IdataOrderItem idata)
        {
            _Idata = idata;
        }

        public async Task<OrderItem> AddOrder(OrderItem order)
        {
            OrderItem orderRes = await _Idata.AddOrder(order);
            if (orderRes != null)
                return orderRes;
            return null;
        }

    }
}
