
using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO 
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int Price { get; set; }

        public int UserId { get; set; }

        public int numOfItems { get; set; }

        public string userName { get; set; }
    }
}
