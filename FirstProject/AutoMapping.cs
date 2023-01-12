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


        }
    }
}
