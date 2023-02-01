using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities { 

public partial class Order
{
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

      
       
   
      
       
        
        public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int Price { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } 

      
        public virtual user? User { get; set; } = null!;
}
}