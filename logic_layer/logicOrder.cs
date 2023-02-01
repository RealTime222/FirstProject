using data_layer;
using entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class logicOrder : IlogicOrder
    {
        private readonly IdataOrder _Idata;
        public logicOrder(IdataOrder idata)
        {
            _Idata = idata;
        }

        public async Task<Order> AddOrder(Order order)
        {
            Order orderRes = await _Idata.AddOrder(order);
            if (orderRes != null)
                return order;
            return null;
        }

    }
}
