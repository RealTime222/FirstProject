using entities;
using DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DTO
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            
            CreateMap<Product, ProductDTO>().ForMember(dest =>
            dest.CategoryName, opt => opt.MapFrom(p => p.Category.CategoryName));

            CreateMap<Category, CategoryDTO>().ForMember(dest =>
                dest.numOfProducts, opt => opt.MapFrom(p => p.Products.Count));

            CreateMap<Order, OrderDTO>().ForMember(dest =>
              dest.numOfItems, opt => opt.MapFrom(p => p.OrderItems.Count)).ForMember
              (dest=>dest.userName, opt=>opt.MapFrom(p=>p.User.FirstName));

            CreateMap<user, UserDTO>().ForMember(dest =>
                dest.numOfOrders, opt => opt.MapFrom(p => p.Orders.Count));


        }
    }
}
