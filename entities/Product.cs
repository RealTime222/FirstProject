using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities { 

public partial class Product
{
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }

        public string ImageUrl { get; set; } = null!;

     
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
    }
}
