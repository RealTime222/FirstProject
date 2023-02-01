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
        private readonly IlogicProduct _IlogicProduct;
        public logicOrder(IdataOrder idata, IlogicProduct logicProduct)
        {
            _Idata = idata;
            _IlogicProduct = logicProduct;
        }

        public async Task<Order> AddOrder(Order order)
        {
            List<int> productIds = new List<int>();
            var orderItems = order.OrderItems.ToArray();
            for (int i = 0; i < orderItems.Length; i++)
            {
                productIds.Add(orderItems[i].ProductId);
            }
            var products = new Product[order.OrderItems.Count];
            products = _IlogicProduct.GetProductsByIDs(productIds.ToArray());
            var sum = 0;
            for (int i = 0; i < products.Length; i++)
            {
                for(int j = 0; j < orderItems.Length;j++)
                {
                    if (products[i].ProductId == orderItems[j].ProductId)
                    {
                        sum += ((products[i].Price) * (orderItems[j].Amount));
                        break;
                    }
                }

                
            }
            order.Price = sum;
            Order orderRes = await _Idata.AddOrder(order);
            if (orderRes != null)
                return orderRes;
            return null;
          
        }

    }
}
