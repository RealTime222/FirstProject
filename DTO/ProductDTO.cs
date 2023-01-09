﻿using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entities;

namespace DTO
{
    public class ProductDTO
    {
       
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }

        public string? Description { get; set; }

        public string ImageUrl { get; set; }
      

        public virtual Category Category { get; set; }
        public string CategoryName { get; set; }


    }
}
